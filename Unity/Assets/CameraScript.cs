using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	float counter;
	Vector3 startPos;
	float startOrthoSize;
	public string state;
	float seeClockCounter;
	Quaternion startRotation;
	float someTimeConstant;
	float timeFix;
	float prevRealTime;
	// Use this for initialization
	void Start () {
		counter = 0;
		startPos = transform.position;
		startOrthoSize = GetComponent<Camera>().orthographicSize;
		startRotation = transform.rotation;
		state = "normal";
		seeClockCounter = 0;
		someTimeConstant = 1 / 0.01656657f;
		//Time.timeScale = 0;
		prevRealTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			timeFix = Time.deltaTime * someTimeConstant;
		} else {
			timeFix = (Time.realtimeSinceStartup-prevRealTime)*someTimeConstant;
		}
		prevRealTime = Time.realtimeSinceStartup;
		//this.transform.Rotate (new Vector3(0,0,-10));
		counter += 0.25f*timeFix;
		if (state != "seeClock") {
			transform.position = startPos+timeFix*new Vector3 (0,Mathf.Sin (counter)*0.05f,0);;
		}
		if (state == "seeClock") {
			seeClockCounter += 1*timeFix;
			Vector3 clockDir = GameObject.Find ("Clock").transform.position - transform.position;
			clockDir.Normalize ();
			//if (clockDir.y > 0.5f) {
			transform.position += timeFix*new Vector3 (clockDir.x * 0.5f/5, clockDir.y * 0.25f - 0.008f, 0);
			GetComponent<Camera>().orthographicSize = Mathf.Clamp (GetComponent<Camera>().orthographicSize - (timeFix*(0.025f/5)), 0.89f, startOrthoSize);
			//}
			if (seeClockCounter>750) {
				state = "seeAss";
				Time.timeScale = 1;
				seeClockCounter = 0;
			}
		}
		if (state == "seeAss") {
			Vector3 assDir = startPos - transform.position;
			//assDir.Normalize ();
			//if (clockDir.y > 0.5f) {
			transform.position += timeFix*new Vector3 (assDir.x * 0.05f, assDir.y * 0.025f, 0);
			GetComponent<Camera>().orthographicSize = Mathf.Clamp (GetComponent<Camera>().orthographicSize + (timeFix*0.025f), 0.89f, startOrthoSize);
			if (GetComponent<Camera>().orthographicSize == startOrthoSize) {
				state = "zoomIn";
			}
			//}
		}
		if (state == "zoomIn") {
			GetComponent<Camera>().orthographicSize = Mathf.Clamp (GetComponent<Camera>().orthographicSize - (timeFix*0.05f), 2f, startOrthoSize);
			if (GetComponent<Camera>().orthographicSize == 2f) {
				state = "zoomOut";
			}
		}
		if (state == "zoomOut") {
			GetComponent<Camera>().orthographicSize = Mathf.Clamp (GetComponent<Camera>().orthographicSize + (timeFix*0.1f), 2f, startOrthoSize);
			if (GetComponent<Camera>().orthographicSize == startOrthoSize) {
				state = "zoomIn";
			}
		}
		if (state == "spin") {
			transform.Rotate(new Vector3(0,0,timeFix*8));
			if (transform.rotation.z<0) {
				transform.rotation = startRotation;
				GetComponent<Camera>().orthographicSize = startOrthoSize;
				transform.position = startPos;
				state = "normal";
			}
		}
	}
}
