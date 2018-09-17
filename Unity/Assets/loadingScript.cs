using UnityEngine;
using System.Collections;

public class loadingScript : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= 0) {
			counter ++;
		}
		if (counter==20) {
			counter = -1;
			Application.LoadLevel("GameScreen");
		}
	}
}
