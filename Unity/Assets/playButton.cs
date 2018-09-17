using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour {
	public GameObject classicMode;
	public GameObject grabMode;
	public GameObject play;
	public GameObject chooseMode;
	public GameObject classicHitbox;
	public GameObject grabHitbox;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		classicMode.SetActive (true);
		classicHitbox.SetActive (true);
		grabMode.SetActive (true);
		grabHitbox.SetActive (true);
		chooseMode.SetActive (true);
		play.SetActive (false);
		gameObject.SetActive (false);
	}
}
