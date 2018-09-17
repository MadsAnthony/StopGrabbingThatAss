using UnityEngine;
using System.Collections;

public class EndScreenGrabButton : MonoBehaviour {

	public EndScreenGrab endScreenGrab;
	bool mouseIsDown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {
		if (endScreenGrab.counter < 100 && !mouseIsDown) {
			endScreenGrab.counter = 100;
			mouseIsDown = true;
		}
		if (endScreenGrab.counter < 200 && !mouseIsDown) {
			endScreenGrab.counter = 200;
			mouseIsDown = true;
		}
		if (endScreenGrab.counter > 100 && !mouseIsDown) {
			Application.LoadLevel("startScreen");
			mouseIsDown = true;
		}
	}
	void OnMouseUp() {
		mouseIsDown = false;
	}
}
