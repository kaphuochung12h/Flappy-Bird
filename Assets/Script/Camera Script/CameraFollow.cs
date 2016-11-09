using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	private Transform bird;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (bird != null) { //Neu bird con song thi camera moi follow theo
			Vector3 temp = transform.position;
			temp.x = bird.position.x + 6f;
			transform.position = temp;
		}
	}
}
