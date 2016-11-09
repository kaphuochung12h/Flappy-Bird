using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	private GameObject[] backgrounds;
	private GameObject[] grounds;
	private float lastBGPositionX;
	private float lastGroundPositionX;
	// Use this for initialization
	void Awake () {
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		grounds = GameObject.FindGameObjectsWithTag ("Ground");

		lastBGPositionX = backgrounds [0].transform.position.x;
		lastGroundPositionX = grounds [0].transform.position.x;

		for (int i = 1; i < backgrounds.Length; i++) {
			if (lastBGPositionX < backgrounds [i].transform.position.x) {
				lastBGPositionX = backgrounds [i].transform.position.x;
			}
		}

		for(int i = 1;i<grounds.Length;i++){
			if (lastGroundPositionX < grounds [i].transform.position.x) {
				lastGroundPositionX = grounds [i].transform.position.x;
			}
	}
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Background") {
			Vector3 temp = target.transform.position;
			float width = ((BoxCollider2D)target).size.x;
			temp.x = lastBGPositionX + width;
			target.transform.position = temp;
			lastBGPositionX = temp.x;
		}else if (target.tag == "Ground") {
			Vector3 temp = target.transform.position;
			float width = ((BoxCollider2D)target).size.x;
			temp.x = lastGroundPositionX + width;
			target.transform.position = temp;
			lastGroundPositionX = temp.x;
		}
	}
}
