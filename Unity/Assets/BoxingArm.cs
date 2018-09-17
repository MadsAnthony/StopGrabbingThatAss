using UnityEngine;
using System.Collections;

public class BoxingArm : MonoBehaviour {

	Vector3 theScale;
	Animator animator;
	float counter;
	Color handBrown = (Color) new Color32(237,194,137,255);
	Color handYellow = (Color) new Color32(255,252,150,255);
	Vector3 distance;
	Vector3 direction;
	float speed = 0.04f;
	float someTimeConstant;
	float timeFix;
	
	public AudioClip soundSwush;
	public AudioClip soundStopGrabbing;
	public GameObject hand;
	public GameObject buttCheek;
	public GameObject mainAss;
	public GameObject glove;
	public GameObject gloveAlone;
	public GameObject arm;
	
	// Use this for initialization
	void Start () {
		counter = 0;
		//animator = this.GetComponent<Animator> ();
		theScale = transform.localScale;
		someTimeConstant = 1 / 0.0171777f;
		//setColor ();
		//GetComponent<SpriteRenderer>().color = (Color) new Color32(237,194,137,255);
		//GetComponent<SpriteRenderer>().color = (Color) new Color32(255,252,150,255);
		if (buttCheek.transform.position.x>transform.position.x-0.5f) {
			transform.localScale = new Vector3(theScale.x*-1,theScale.y,theScale.z);
		}
	}
	void setColor() {
		int num = Random.Range (1, 100);
		if (num>0 && num<=70) {
		}
		if (num>70 && num<=90) {
			GetComponent<SpriteRenderer>().color = handBrown;
		}
		if (num>90 && num<=100) {
			GetComponent<SpriteRenderer>().color = handYellow;
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
		Vector3 tmpDistance = (buttCheek.transform.position - new Vector3 (-0.5f * Mathf.Sign (transform.localScale.x), 1.4f, 0)) - transform.position;
		//speed += 0.001f;
		if (tmpDistance.x >= speed || tmpDistance.y >= speed) {
			transform.position += timeFix*direction * speed;
		} else {
			mainAss.GetComponent<MainScript> ().assGettingGrabbed (timeFix*0.01f);
		}
		if (transform.position.y<-20f) {
			Destroy (gameObject);
		}
	}
	void OnMouseDown()
	{
		Destroy (glove);
		//gloveAlone.GetComponent<HandScript> ().handColor = GetComponent<SpriteRenderer>().color;
		gloveAlone.GetComponent<HandScript> ().direction = theScale.x/transform.localScale.x;
		gloveAlone.GetComponent<HandScript> ().gravity = -25-Random.Range(0,5);
		gloveAlone.GetComponent<HandScript> ().bloodIsOn = false;
		Instantiate (gloveAlone, transform.position + new Vector3 (-0.1f, 1.4f, -0.5f), Quaternion.identity);

		//GameObject arm = mainAss.GetComponent<MainScript> ().arm;
		arm.GetComponent<ArmScript>().buttCheek = buttCheek;
		arm.GetComponent<ArmScript>().mainAss = this.mainAss;
		arm.GetComponent<ArmScript>().armColorOn = false;
		Instantiate (arm,transform.position+new Vector3 (0.8f* Mathf.Sign (transform.localScale.x), -0.25f, 0f), Quaternion.identity);
		Destroy (gameObject);
		/*
		if (!animator.GetBool ("isHandCutOff")) {
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
		}
		*/
	}
}
