using UnityEngine;
using System.Collections;

public class ChristmasButton : MonoBehaviour {
	public GameObject On;
	public GameObject Off;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("isChristmas") == 1) {
			On.GetComponent<TextMesh>().color = new Color(1,1,1);
			Off.GetComponent<TextMesh>().color = new Color(0.5f,0.5f,0.5f);
		} else {
			On.GetComponent<TextMesh>().color = new Color(0.5f,0.5f,0.5f);
			Off.GetComponent<TextMesh>().color = new Color(1,1,1);
		}
	}
	void OnMouseDown()
	{
		if (PlayerPrefs.GetInt ("isChristmas") == 1) {
			PlayerPrefs.SetInt ("isChristmas", 0);
		} else {
			PlayerPrefs.SetInt ("isChristmas", 1);
		}
	}
}
