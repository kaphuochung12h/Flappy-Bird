using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {
	public static SceneFader instance;
	[SerializeField]
	private GameObject fadeCanvas;
	[SerializeField]
	private Animator fadeAnim;
	void Awake(){
		MakeASingleInstance ();
	}
	void MakeASingleInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	IEnumerator FadeInAnimate(string levelName){
		fadeCanvas.SetActive (true);
		fadeAnim.Play ("FadeIn");
		yield return StartCoroutine(MyCoroutine.WaitForRealSeccond(.7f));
		Application.LoadLevel (levelName);
		FadeOut ();
	}
	IEnumerator FadeOutAnimate(){
		fadeAnim.Play ("FadeOut");
		yield return StartCoroutine(MyCoroutine.WaitForRealSeccond(1f));
		fadeCanvas.SetActive (false);
	}
	public void FadeIn(string levelName){
		StartCoroutine (FadeInAnimate (levelName));
	}
	public void FadeOut(){
		StartCoroutine (FadeOutAnimate ());
	}
}
