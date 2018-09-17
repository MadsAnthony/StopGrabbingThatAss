using UnityEngine;
using System.Collections;

public class SnowFlakeScript : MonoBehaviour {
	float counter;
	float counter2;
	int randI;
	int randI2;
	Vector3 startPos;
	Vector3 startScale;
	float someTimeConstant;
	float timeFix;
	// Use this for initialization
	void Start () {
		setupVariables ();
	}
	void setupVariables() {
		startPos = new Vector3 (transform.position.x,4,transform.position.z);
		startScale = transform.localScale;
		randI = Random.Range (1, 3);
		randI2 = Random.Range (1, 50);
		transform.localScale *= (1+(randI2/50f)*-0.2f);
		counter = randI2/2f;
		counter2 = 0;
		GetComponent<SpriteRenderer>().enabled = true;
		someTimeConstant = 1 / 0.0171777f;
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (Time.timeScale == 0) {
			return;
		}
		counter += timeFix*0.1f;
		counter2 += timeFix*0.1f;
		//transform.localScale += new Vector3 (-0.001f*randI, -0.001f*randI, 0);
		/*if (transform.localScale.x<=0) {
			GetComponent<SpriteRenderer>().enabled = false;
		}*/
		transform.position += timeFix*new Vector3 ((randI/100f)*Mathf.Cos (counter), -(0.02f+counter2*0.001f), 0);
		if (transform.position.y < -4) {
			transform.position = startPos;
			transform.localScale = startScale;
			setupVariables ();
			//Destroy (gameObject);
		}
	}
	/*void OnTriggerEnter(Collider c) {
		GetComponent<SpriteRenderer>().enabled = false;
	}*/
}
