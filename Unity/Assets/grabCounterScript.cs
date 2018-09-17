using UnityEngine;
using System.Collections;

public class grabCounterScript : MonoBehaviour {

	TextMesh textM;
	public int textCount = 0;
	// Use this for initialization
	void Start () {
		textM = transform.GetComponentInChildren<TextMesh> ();
		textM.text = textCount+"";
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, 0.03f, 0);
		transform.localScale *= 1.01f;
		textM.color += new Color (0, 0, 0, -0.01f);
	}
}
