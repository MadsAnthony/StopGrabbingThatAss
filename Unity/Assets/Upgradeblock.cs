using UnityEngine;
using System.Collections;

public class Upgradeblock : MonoBehaviour {

	bool isOn = false;
	public TextMesh priceText;
	public int price;
	public GameObject overlay;
	public GameObject coin;
	public GameObject checkmark;
	public GameObject icon;
	public bool isBought;
	public string id;

	// Use this for initialization
	void Start () {
		priceText.text = ""+price;
		//overlay.renderer.enabled = false;
		priceText.GetComponent<TextMesh> ().color = (Color)new Color32 (255, 255, 255, 255);
		checkmark.GetComponent<Renderer>().enabled = false;
		isBought = false;
		if (PlayerPrefs.HasKey ("upgradeBlock" + id)) {
			if (PlayerPrefs.GetInt ("upgradeBlock" + id) == 1) {
				isBought = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isBought) {
			if (price <= GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney) {
				overlay.GetComponent<SpriteRenderer> ().color = (Color)new Color32 (109, 255, 75, 60);
				priceText.GetComponent<TextMesh>().color = (Color)new Color32 (255, 255, 255, 255);
			} else {
				overlay.GetComponent<SpriteRenderer> ().color = (Color)new Color32 (0, 0, 0, 100);
				priceText.GetComponent<TextMesh>().color = (Color)new Color32 (185, 76, 76, 255);
			}
		} else {
			priceText.GetComponent<Renderer>().enabled = false;
			overlay.GetComponent<Renderer>().enabled = false;
			coin.GetComponent<Renderer>().enabled = false;
			icon.GetComponent<SpriteRenderer> ().color = (Color)new Color32 (255, 255, 255, 255);
			if (PlayerPrefs.GetInt("isOn"+id) == 1) {
				checkmark.GetComponent<Renderer>().enabled = true;
				isOn = true;
			} else {
				checkmark.GetComponent<Renderer>().enabled = false;
				isOn = false;
			}
		}
	}

	void OnMouseDown()
	{
		if (!isBought && price <= GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney) {
			isBought = true;
			GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney -= price;
			PlayerPrefs.SetInt("upgradeBlock"+id,1);
			PlayerPrefs.SetInt ("totalScore", GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney);
		}
		if (isBought) {
			if (isOn && GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().numberOfHands == 1) {
				return;
			}
			if (!isOn) {
				priceText.GetComponent<Renderer>().enabled = false;
				overlay.GetComponent<Renderer>().enabled = false;
				coin.GetComponent<Renderer>().enabled = false;
				checkmark.GetComponent<Renderer>().enabled = true;
				icon.GetComponent<SpriteRenderer> ().color = (Color)new Color32 (255, 255, 255, 255);
				GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().activeHands += 1;
				PlayerPrefs.SetInt("isOn"+id,1);
			}
			if (isOn) {
				priceText.GetComponent<Renderer>().enabled = false;
				overlay.GetComponent<Renderer>().enabled = false;
				coin.GetComponent<Renderer>().enabled = false;
				checkmark.GetComponent<Renderer>().enabled = false;
				GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().activeHands -= 1;
				PlayerPrefs.SetInt("isOn"+id,0);
				//icon.GetComponent<SpriteRenderer> ().color = (Color)new Color32 (0, 0, 0, 255);
			}
		}
	}
	void OnMouseUp()
	{
		if (isBought) {
			if (isOn && GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().numberOfHands == 1) {
			}
			isOn = !isOn;
		}
	}
}
