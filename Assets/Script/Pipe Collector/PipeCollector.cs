using UnityEngine;
using System.Collections;

public class PipeCollector : MonoBehaviour {

	private GameObject[] pipeHolders;
	private  float lastPipe;
	private float distance = 3f;
	private float min = -1f;
	private float max = 1.1f;
	// Use this for initialization
	void Awake () {
		pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

		for (int i = 1; i < pipeHolders.Length; i++) {
			Vector3 temp = pipeHolders [i].transform.position;
			temp.y = Random.Range (min, max);
			pipeHolders [i].transform.position = temp;
		}
		lastPipe = pipeHolders [0].transform.position.x;
		for (int i = 1; i < pipeHolders.Length; i++) {
			if (lastPipe < pipeHolders [i].transform.position.x) {
				lastPipe = pipeHolders [i].transform.position.x;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "PipeHolder") {
			Vector3 temp = target.transform.position;
			temp.x = lastPipe + distance;
			temp.y = Random.Range (min, max);
			target.transform.position = temp;
			lastPipe = temp.x;
		}
	}
}
