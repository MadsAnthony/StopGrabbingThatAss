using UnityEngine;
using System.Collections;

public class EndScriptButton : MonoBehaviour {

	// Use this for initialization
	public GameObject endScreenObject;
	EndScreenScript endScreenScript;
	bool mouseIsDown;
	void Start () {
		endScreenScript = endScreenObject.GetComponent<EndScreenScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		if (endScreenScript.currentMoneyVar < endScreenScript.desiredMoney && !mouseIsDown) {
			endScreenScript.currentMoneyVar = endScreenScript.desiredMoney;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2 < 50 && !mouseIsDown) {
			endScreenScript.counter2 = 50;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2 > 50 && endScreenScript.counter2 < 150 && !mouseIsDown) {
			endScreenScript.counter2 = 150;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2 > 150 && endScreenScript.counter2 < 200 && !mouseIsDown) {
			endScreenScript.counter2 = 200;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2>200 && endScreenScript.counter2 < 250 && !mouseIsDown) {
			endScreenScript.counter2 = 250;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2>250 && endScreenScript.counter2 < 300 && !mouseIsDown) {
			endScreenScript.counter2 = 300;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2>300 && endScreenScript.extraMoneyVar > 0 && !mouseIsDown) {
			endScreenScript.extraMoneyVar = 0;
			mouseIsDown = true;
		}
		if (endScreenScript.counter2>300 && endScreenScript.extraMoneyVar == 0 && !mouseIsDown) {
			Application.LoadLevel("startScreen");
			mouseIsDown = true;
		}
	}
	void OnMouseUp() {
		mouseIsDown = false;
	}
}
