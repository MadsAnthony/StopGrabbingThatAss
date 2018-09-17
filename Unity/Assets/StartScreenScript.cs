using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	public string gotoScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		Application.LoadLevel(gotoScene);
	}
}
