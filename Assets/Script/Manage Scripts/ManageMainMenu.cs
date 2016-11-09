using UnityEngine;
using System.Collections;

public class ManageMainMenu : MonoBehaviour {

	public void StartButton(){
		//Application.LoadLevel ("GamePlay");
		SceneFader.instance.FadeIn("GamePlay");
	}
}
