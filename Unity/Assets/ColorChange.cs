using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {
	float someTimeConstant;
	float timeFix;
	// Use this for initialization
	void Start () {
		someTimeConstant = 1 / 0.0171777f;
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (Time.timeScale == 0) {
			return;
		}
		Color32 currentColor = GetComponent<SpriteRenderer> ().color;
		GetComponent<SpriteRenderer> ().color = new Color32 ((byte)(currentColor.r+timeFix*10), (byte)(currentColor.g+timeFix*10), (byte)(currentColor.b+timeFix*10), currentColor.a);
	}
	public void DestroyColorChange() {
		Destroy (gameObject);
	}
}
