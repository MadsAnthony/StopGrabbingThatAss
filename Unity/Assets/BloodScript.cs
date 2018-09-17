using UnityEngine;
using System.Collections;

public class BloodScript : MonoBehaviour {

	public float rotation;
	public float direction;
	public float gravity;
	float someTimeConstant;
	float timeFix;

	// Use this for initialization
	void Start () {
		someTimeConstant = 1 / 0.0171777f;
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (transform.localScale.x > 0) {
			transform.localScale += timeFix*new Vector3 (-0.03f, 0, 0);
		}
		if (transform.localScale.y > 0) {
			transform.localScale += timeFix*new Vector3 (0, -0.03f, 0);
		}
		if (transform.localScale.x <= 0 || transform.localScale.y <= 0) {
			Destroy(gameObject);
		}
		gravity += 0.5f;
		int randNum = Random.Range (1, 5);
		transform.position += new Vector3 (randNum*0.05f * Mathf.Sin (rotation / 180 * Mathf.PI), randNum*-0.05f * Mathf.Cos (rotation / 180 * Mathf.PI)-0.01f*gravity, 0);
	}
}
