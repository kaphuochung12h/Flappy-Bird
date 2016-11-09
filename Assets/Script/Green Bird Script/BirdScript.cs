using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BirdScript : MonoBehaviour {
	public static BirdScript instance;
	//Toc do 
	public float moveForce;
	//Do nhay
	public float bounceForce;

	//Va cham
	private Rigidbody2D mybody;
	private Animator anim;
	//Nhan vao button, bird nhay 1 lan
	private bool didFlap;
	//Kiem tra bird con song hay khong de di chuyen v nhay len, nguoc lai thi khong
	private bool birdIsAlive;
	private Button flapButton;
	[SerializeField]
	private AudioSource audio;
	[SerializeField]
	private AudioClip flapClip, pingClip, dieClip;
	public int score = 0;
	void Awake(){
		mybody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		birdIsAlive = true;
		//add scrip vao buton
		flapButton = GameObject.Find ("Flappy Button").GetComponent<Button> ();
		flapButton.onClick.AddListener (()=>Flapbutton());
		MakeInstance ();
	}
	// Use this for initialization
	void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	//Di chuyen khi co physic
	void FixedUpdate () {
		birdFlappy ();
	}
	void birdFlappy(){
		//Di chuyen
		if(birdIsAlive){
			Vector2 temp = transform.position; // Lay vi tri bird
			temp.x +=  moveForce * Time.deltaTime; //x: di chuyen theo chieu ngang
			transform.position = temp;
			//Nhay
			if(didFlap){
				didFlap = false;
				mybody.velocity = new Vector2 (0, bounceForce);
				audio.PlayOneShot (flapClip);
				anim.SetTrigger ("Flap");
			}
		}
		if (mybody.velocity.y == 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0); // vi tri bird = 0 thi ko cho xoay
		}else if(mybody.velocity.y < 0){
			float angel = 0f; // goc xoay
			angel = Mathf.Lerp(0f,-90f,-mybody.velocity.y/9f);
			transform.rotation = Quaternion.Euler (0, 0, angel);
		}else if(mybody.velocity.y > 0){
			float angel = 0f;
			angel = Mathf.Lerp(0f,90f,mybody.velocity.y/9f);
			transform.rotation = Quaternion.Euler (0, 0, angel);
		}
}
	public void Flapbutton(){
		didFlap = true;
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe") {
			if (birdIsAlive) {
				birdIsAlive = false;
				anim.SetTrigger ("Die");
				audio.PlayOneShot (dieClip);
				GamePlayManager.instance.BirdDiedShowPanel (score);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "PipeHolder") {
			score++;
			GamePlayManager.instance.IncreasementScore (score);
			audio.PlayOneShot (pingClip);

		}
	}
}