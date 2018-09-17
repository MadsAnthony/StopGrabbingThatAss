using UnityEngine;
using System.Collections;

public class DavidHandScript : MonoBehaviour {
	
	Vector3 theScale;
	float counter;
	public float direction;
	public float gravity;
	public Color handColor;
	public GameObject blood;
	public bool bloodIsOn = true;
	public GameObject ring;
	public GameObject normalHand;
	public GameObject rock;
	public GameObject paper;
	public GameObject scissor;
	public GameObject rockText;
	public GameObject paperText;
	public GameObject scissorText;
	float someTimeConstant;
	float timeFix;
	// Use this for initialization
	void Start () {
		counter = 0;
		//GetComponent<SpriteRenderer>().color = handColor;
		theScale = transform.localScale;
		//blood.GetComponent<BloodScript> ().rotation = transform.eulerAngles.z;
		//blood.GetComponent<BloodScript> ().gravity = -2-Random.Range(0,2);
		//Instantiate (blood, transform.position + new Vector3 (-0.1f, 1.4f, 0), Quaternion.identity);
		rock.GetComponent<Renderer>().enabled = false;
		paper.GetComponent<Renderer>().enabled = false;
		scissor.GetComponent<Renderer>().enabled = false;
		someTimeConstant = 1 / 0.0171777f;
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
		gravity += timeFix*0.5f;
		transform.localScale = new Vector3(theScale.x*Mathf.Sign (direction),theScale.y,theScale.z);
		transform.position += timeFix*new Vector3(0.05f*direction,-0.01f*gravity,0);
		this.transform.Rotate (new Vector3(0,0,timeFix*-5*Mathf.Sign (direction)));
		if (transform.position.y<-5f) {
			Destroy (gameObject);
		}
	}
	void OnMouseOver()
	{
		if (gravity >= 0) {
			ring.GetComponent<Renderer>().enabled = false;
			normalHand.GetComponent<Renderer>().enabled = false;
			rock.GetComponent<Renderer>().enabled = false;
			paper.GetComponent<Renderer>().enabled = false;
			scissor.GetComponent<Renderer>().enabled = false;
			int rNumber = Random.Range (0, 3);
			if (rNumber == 0) {
				rock.GetComponent<Renderer>().enabled = true;
				Instantiate(rockText,new Vector3(transform.position.x,transform.position.y,-4),Quaternion.identity);
			}
			if (rNumber == 1) {
				paper.GetComponent<Renderer>().enabled = true;
				Instantiate(paperText,new Vector3(transform.position.x,transform.position.y,-4),Quaternion.identity);
			}
			if (rNumber == 2) {
				scissor.GetComponent<Renderer>().enabled = true;
				Instantiate(scissorText,new Vector3(transform.position.x,transform.position.y,-4),Quaternion.identity);
			}
			gravity = -15;
			int rDir = 0;
			if (Mathf.Abs (direction)<1) {
				rDir = Random.Range(0,2);
			}
			direction *= -0.5f-rDir;
		}
	}
}
