using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public static ScoreManager instance;
	private const string highScore = "High Score";
	[SerializeField]
	private Text scoreText;
	void Awake(){
		MakeASingleInstance ();
	}
	void MakeASingleInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	public void IncreasementScore(int score){
		scoreText.text = "" + score;
	}
	public void SetHighScore(int score){
		PlayerPrefs.SetInt (highScore, score);
	}
	public int GetHighScore(){
		return PlayerPrefs.GetInt (highScore);
	}
}
