using UnityEngine;
using System.Collections;

public class UpgradeScreenScript : MonoBehaviour {

	// Use this for initialization
	bool mouseIsDown;
	Vector3 mouseStartPos;

	public TextMesh totalMoneyText;
	public TextMesh incMoneyText;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseStartPos = Input.mousePosition;
			mouseIsDown = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseIsDown = false;
		}
		if (mouseIsDown) {
			transform.position -= new Vector3 (0,((mouseStartPos-Input.mousePosition)*0.012f).y,0);
			mouseStartPos = Input.mousePosition;
		}
		transform.position = new Vector3 (transform.position.x,Mathf.Clamp (transform.position.y, -1, 0.2f),transform.position.z);
		totalMoneyText.text = ""+GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney;
		incMoneyText.text = GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().numberOfHands+" +";
	}
}
