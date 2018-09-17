using UnityEngine;
using System.Collections;

public class RockPaperScissorScript : MonoBehaviour {

	int counter;
	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		counter ++;
		if (counter > 80) {
			Destroy(gameObject);
		}
	}
}
