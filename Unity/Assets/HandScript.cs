using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour {

	Vector3 theScale;
	float counter;
	public float direction;
	public float gravity;
	public Color handColor;
	public GameObject blood;
	public bool bloodIsOn = true;
	float someTimeConstant;
	float timeFix;

	// Use this for initialization
	void Start () {
		counter = 0;
		GetComponent<SpriteRenderer>().color = handColor;
		theScale = transform.localScale;
		someTimeConstant = 1 / 0.0171777f;
		//blood.GetComponent<BloodScript> ().rotation = transform.eulerAngles.z;
		//blood.GetComponent<BloodScript> ().gravity = -2-Random.Range(0,2);
		//Instantiate (blood, transform.position + new Vector3 (-0.1f, 1.4f, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (Time.timeScale == 0) {
			return;
		}
		if (bloodIsOn) {
			float rotation = transform.eulerAngles.z;
			blood.GetComponent<BloodScript> ().rotation = rotation;
			blood.GetComponent<BloodScript> ().direction = direction;
			blood.GetComponent<BloodScript> ().gravity = -2 - Random.Range (0, 2);
			counter += timeFix*1;
			if (counter < 35) {
				Instantiate (blood, transform.position + new Vector3 (0.4f * Mathf.Sin (rotation / 180 * Mathf.PI), -0.5f * Mathf.Cos (rotation / 180 * Mathf.PI), 0.01f), Quaternion.identity);
			}
		}
		gravity += timeFix*1;
		transform.localScale = new Vector3(theScale.x*direction,theScale.y,theScale.z);
		transform.position += timeFix*new Vector3(0.05f*direction,-0.01f*gravity,0);
		this.transform.Rotate (new Vector3(0,0,timeFix*-5*direction));
		if (transform.position.y<-5f) {
			Destroy (gameObject);
		}
	}
	void OnMouseOver()
	{
		if (gravity >= 0) {
			gravity = -25;
			direction *= -1;
		}
	}
}
