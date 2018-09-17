using UnityEngine;
using System.Collections;

public class GeneralScript : MonoBehaviour {

	public int totalMoney = 0;
	public int currentMoney = 0;
	public int activeHands = 1;
	public int numberOfHands;
	public string mode;
	public int grabScore;
	// Use this for initialization
	void Start () {
		mode = "normal";
		if (!PlayerPrefs.HasKey ("isCensorOn")) {
			PlayerPrefs.SetInt ("isCensorOn", 0); //Use this for everything else than Apple
		}
		//PlayerPrefs.SetInt ("isCensorOn",1); //Use this for Apple
		if (!PlayerPrefs.HasKey ("isChristmas")) {
			PlayerPrefs.SetInt ("isChristmas", 0);
		}
		if (PlayerPrefs.HasKey ("totalScore")) {
			totalMoney = PlayerPrefs.GetInt ("totalScore");
		}
		if (!PlayerPrefs.HasKey ("isOn" + "regularHand")) {
			PlayerPrefs.SetInt ("isOn" + "regularHand",1);
		}
		if (!PlayerPrefs.HasKey ("upgradeBlock" + "regularHand")) {
			PlayerPrefs.SetInt ("upgradeBlock" + "regularHand",1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		activeHands = Mathf.Clamp (activeHands, 1, 3);
		numberOfHands = 0;
		if (PlayerPrefs.HasKey ("isOn" + "regularHand")) {
			if (PlayerPrefs.GetInt ("isOn" + "regularHand") == 1) {
				numberOfHands ++;
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "handOfDavid")) {
			if (PlayerPrefs.GetInt ("isOn" + "handOfDavid") == 1) {
				numberOfHands ++;
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "theBoxer")) {
			if (PlayerPrefs.GetInt ("isOn" + "theBoxer") == 1) {
				numberOfHands ++;
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "cartoonHand")) {
			if (PlayerPrefs.GetInt ("isOn" + "cartoonHand") == 1) {
				numberOfHands ++;
			}
		}
	}
	// Make this game object and all its transform children
	// survive when loading a new scene.
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}
}
