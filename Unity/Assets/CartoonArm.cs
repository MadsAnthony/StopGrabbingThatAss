using UnityEngine;
using System.Collections;

public class CartoonArm : MonoBehaviour {

	Vector3 theScale;
	Animator animator;
	float counter;
	Color handBrown = (Color) new Color32(237,194,137,255);
	Color handYellow = (Color) new Color32(255,252,150,255);
	Vector3 distance;
	Vector3 direction;
	float speed = 0.03f;
	bool isDefeated = false;
	float someTimeConstant;
	float timeFix;
	
	public AudioClip soundSwush;
	public AudioClip soundStopGrabbing;
	public GameObject hand;
	public GameObject buttCheek;
	public GameObject mainAss;
	public bool armColorOn = true;
	
	// Use this for initialization
	void Start () {
		counter = 0;
		animator = this.GetComponent<Animator> ();
		theScale = transform.localScale;
		someTimeConstant = 1 / 0.0171777f;
		//GetComponent<SpriteRenderer>().color = (Color) new Color32(237,194,137,255);
		//GetComponent<SpriteRenderer>().color = (Color) new Color32(255,252,150,255);
		if (buttCheek.transform.position.x>transform.position.x-0.5f) {
			transform.localScale = new Vector3(theScale.x*-1,theScale.y,theScale.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (Time.timeScale == 0) {
			return;
		}
		if (counter == 0) {
			distance = (buttCheek.transform.position - new Vector3 (-0.5f * Mathf.Sign (transform.localScale.x), 1.4f, 0)) - transform.position;
			direction = distance;
			direction.Normalize ();
		}
		if (isDefeated) {
			counter += timeFix*0.5f;
			transform.position += timeFix*new Vector3 (0.1f * Mathf.Sin (counter) + 0.01f, -0.04f*5, 0);
		} else {
			Vector3 tmpDistance = (buttCheek.transform.position - new Vector3 (-0.5f * Mathf.Sign (transform.localScale.x), 1.4f, 0)) - transform.position;
			speed += timeFix*0.001f;
			if (tmpDistance.x >= speed || tmpDistance.y >= speed) {
				transform.position += timeFix*direction * speed;
			} else {
				mainAss.GetComponent<MainScript> ().assGettingGrabbed (timeFix*0.01f);
			}
		}
		if (transform.position.y<-20f) {
			Destroy (gameObject);
		}
	}
	void OnMouseDown()
	{
		if (!isDefeated) {
			GetComponent<AudioSource>().PlayOneShot (soundSwush);
			mainAss.GetComponent<MainScript>().points += mainAss.GetComponent<MainScript>().incPoints;
			mainAss.GetComponent<MainScript>().ScorePoints.text = ""+mainAss.GetComponent<MainScript>().points;
			isDefeated = true;
		}
		/*if (!animator.GetBool ("isHandCutOff")) {
			mainAss.GetComponent<MainScript>().points += 1;
			mainAss.GetComponent<MainScript>().ScorePoints.text = ""+mainAss.GetComponent<MainScript>().points;
			audio.PlayOneShot(soundSwush);
			if (Random.Range (0,100)<30) {
				audio.PlayOneShot(soundStopGrabbing,10.0f);
			}
			animator.SetBool ("isHandCutOff", true);
			hand.GetComponent<HandScript> ().handColor = GetComponent<SpriteRenderer>().color;
			hand.GetComponent<HandScript> ().direction = theScale.x/transform.localScale.x;
			hand.GetComponent<HandScript> ().gravity = -20-Random.Range(0,5);
			Instantiate (hand, transform.position + new Vector3 (-0.1f, 1.4f, -0.5f), Quaternion.identity);
		}*/
	}
}
