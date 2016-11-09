using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {

	public static GamePlayManager instance;
	[SerializeField]
	private Button instruction, resume, pause;
	[SerializeField]
	private Text GameOver,ScoreText,endScoreText,highScoreText ;
	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private Image medalImage;
	[SerializeField]
	private Sprite[] medalList;
	void Awake (){
		MakeInstance ();
		Time.timeScale = 0f;
	}
	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}
	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
		pause.gameObject.SetActive (false);
		endScoreText.text = "" + BirdScript.instance.score ;
		highScoreText.text = "" + ScoreManager.instance.GetHighScore ();

		resume.onClick.RemoveAllListeners ();
		resume.onClick.AddListener (()=>resumeGame());
	}
	public void resumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
		pause.gameObject.SetActive (true);
	}
	public void restartGame(){
		Time.timeScale = 1f;
		//Application.LoadLevel ("GamePlay");
		SceneFader.instance.FadeIn("GamePlay");
	}
	public void BirdDiedShowPanel(int score){
		ScoreText.gameObject.SetActive (false);
		GameOver.gameObject.SetActive (true);
		pausePanel.SetActive  (true);
		pause.gameObject.SetActive (false);
		endScoreText.text = "" + score;
		if(score>ScoreManager.instance.GetHighScore()){
			ScoreManager.instance.SetHighScore (score);
		}
		highScoreText.text = "" + ScoreManager.instance.GetHighScore ();
		if (score <= 5) {
			medalImage.sprite = medalList [0];
		} else if (score > 5 || score <= 10) {
			medalImage.sprite = medalList [1];
		} else {
			medalImage.sprite = medalList [2];
		}
			
		resume.onClick.RemoveAllListeners ();
		resume.onClick.AddListener (()=>restartGame());
	}
	public void InstructionButton(){
		Time.timeScale = 1f;
		instruction.gameObject.SetActive (false);
		ScoreText.gameObject.SetActive (true);
	}
	public void IncreasementScore(int score ){
		ScoreText.text = "" + score;
	}
	public void MainMenu(){
		//Application.LoadLevel ("Menu");
		SceneFader.instance.FadeIn("Menu");
	}
}
