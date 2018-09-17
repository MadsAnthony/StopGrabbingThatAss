using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	public string gotoScene;
	public string mode;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().mode = mode;
		Application.LoadLevel(gotoScene);
	}
}
