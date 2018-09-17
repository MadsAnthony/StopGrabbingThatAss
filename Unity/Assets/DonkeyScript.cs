using UnityEngine;
using System.Collections;

public class DonkeyScript : MonoBehaviour {
	float counter;
	AudioSource audio;

	public AudioClip donkeySound;
	// Use this for initialization
	void Start () {
		counter = 10;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		counter += Time.deltaTime;
		if (counter > 20) {
			audio.PlayOneShot (donkeySound, 1);
			counter = 0;
		}
	}
}
