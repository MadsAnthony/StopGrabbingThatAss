using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MainScript : MonoBehaviour {
	float counter;
	float clockEventActiveCounter;
	UnityEngine.Object crazyColorObjectTmp;
	private int minute;
	private int hour;
	private bool clockEventActive;
	public GameObject arm;
	public GameObject boxingArm;
	public GameObject cartoonArm;
	public GameObject davidArm;
	public GameObject buttCheek1;
	public GameObject buttCheek2;
	public TextMesh ScoreText;
	public TextMesh ScorePoints;
	public int points;
	public int incPoints;
	public GameObject HealthContent;
	public GameObject CrazyColorOverlay;
	public AudioClip CrazyTechnoMusic;
	public List<GameObject> armList;
	public GameObject ChristmasDeco;
	public AudioClip GrabThatAss;
	public GameObject grabCounter;
	public TextMesh grabTimer;
	public GameObject Donkey;
	float countDown;
	string mode;
	TextMesh textClock;
	GameObject myCamera;
	int grabCounterScore;
	Vector3 newGrabPos;
	float someTimeConstant;
	float timeFix;
	bool isTmpSpin;


	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find("Main Camera");
		counter = 0;
		points = 0;
		//hour = Random.Range(0,24);
		minute = Random.Range(9*60,10*60+30);
		clockEventActiveCounter = 0;
		armList = new List<GameObject>();
		if (PlayerPrefs.HasKey ("isOn" + "regularHand")) {
			if (PlayerPrefs.GetInt ("isOn" + "regularHand") == 1) {
				armList.Add (arm);
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "handOfDavid")) {
			if (PlayerPrefs.GetInt ("isOn" + "handOfDavid") == 1) {
				armList.Add (davidArm);
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "theBoxer")) {
			if (PlayerPrefs.GetInt ("isOn" + "theBoxer") == 1) {
				armList.Add (boxingArm);
			}
		}
		if (PlayerPrefs.HasKey ("isOn" + "cartoonHand")) {
			if (PlayerPrefs.GetInt ("isOn" + "cartoonHand") == 1) {
				armList.Add (cartoonArm);
			}
		}
		incPoints = armList.Count;
		Animator anim = GetComponent<Animator> ();
		if (PlayerPrefs.GetInt ("isChristmas") == 1) {
			anim.SetBool ("isChristmas", true);
			ChristmasDeco.SetActive(true);
			ChristmasDeco.GetComponent<AudioSource>().Play ();
		} else {
			anim.SetBool ("isChristmas", false);
			ChristmasDeco.SetActive(false);
		}
		if (PlayerPrefs.GetInt ("isCensorOn") == 1) {
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<Animator>().enabled = false;
			Donkey.SetActive(true);
		} else {
			Donkey.SetActive(false);
		}
		textClock = GameObject.Find ("Clock/Time").GetComponent<TextMesh> ();
		mode = GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().mode;
		//mode = "normal";
		grabCounterScore = 0;
		countDown = 1560;
		if (mode == "normal") {
			grabTimer.GetComponent<Renderer>().enabled = false;
		}
		if (mode == "grab") {
			transform.position += new Vector3(0,0,-4f);
		}
		newGrabPos = transform.position;
		someTimeConstant = 1 / 0.0171777f;
	}
	
	// Update is called once per frame
	void Update () {
		timeFix = Time.deltaTime * someTimeConstant;
		if (Time.timeScale == 0) {
			if (ChristmasDeco.activeSelf) {
				ChristmasDeco.GetComponent<AudioSource>().Pause ();
			}
			return;
		}
		if (ChristmasDeco.activeSelf) {
			if (!ChristmasDeco.GetComponent<AudioSource>().isPlaying && myCamera.GetComponent<CameraScript> ().state == "normal") {
				ChristmasDeco.GetComponent<AudioSource>().Play ();
			}
		}
		string zeroHour = "";
		string zeroMin = "";
		hour = ((int) Mathf.Round(minute / 60))%24;
		if (hour < 10) {
			zeroHour = "0";
		}
		if (hour < 10) {
			zeroHour = "0";
		}
		if (minute%60 < 10) {
			zeroMin = "0";
		}
		if (clockEventActive) {
			clockEventActiveCounter += timeFix*1;
			if (crazyColorObjectTmp == null) {
				crazyColorObjectTmp = Instantiate (CrazyColorOverlay, new Vector3 (0, 0, -1), Quaternion.identity);
				isTmpSpin = false;
			}
		}
		if (clockEventActiveCounter>750 && clockEventActiveCounter<=800 && !isTmpSpin) {
			myCamera.GetComponent<CameraScript> ().state = "spin";
			isTmpSpin = true;
		}
		if (clockEventActiveCounter>800) {
			clockEventActiveCounter = 0;
			Destroy(crazyColorObjectTmp);
			clockEventActive = false;
		}
		if (hour%24 == 10 && minute % 60 == 45 && !clockEventActive) {
			myCamera.GetComponent<CameraScript>().state = "seeClock";
			GetComponent<AudioSource>().PlayOneShot(CrazyTechnoMusic,10.0f);
			clockEventActive = true;
			Time.timeScale = 0;
		}
		/*if (counter == 20) {
			Instantiate (CrazyColorOverlay,new Vector3(0,0,-1), Quaternion.identity);
		}*/
		textClock.text = ""+zeroHour+hour+":"+zeroMin+minute%60;
		if (mode == "normal") {
			counter += timeFix*1;
			if (counter>60) {
				minute ++;
				GameObject tmpButtCheek;
				int rNum = Random.Range (-8, 8);
				if (rNum == 0) {
						rNum = 1;
				}
				if (rNum < 0) {
						tmpButtCheek = buttCheek2;
				} else {
						tmpButtCheek = buttCheek1;
				}
				//arm.GetComponent<ArmScript>().buttCheek1 = tmpButtCheek;
				int armI = Random.Range (0, armList.Count);
				if (armList [armI] == arm) {
						arm.GetComponent<ArmScript> ().buttCheek = tmpButtCheek;
						arm.GetComponent<ArmScript> ().mainAss = this.gameObject;
						arm.GetComponent<ArmScript> ().armColorOn = true;
						Instantiate (armList [armI], new Vector3 (rNum, -5 - (Random.Range (0, 100) / 100), 0), Quaternion.identity);
				}
				if (armList [armI] == davidArm) {
						davidArm.GetComponent<DavidArm> ().buttCheek = tmpButtCheek;
						davidArm.GetComponent<DavidArm> ().mainAss = this.gameObject;
						Instantiate (armList [armI], new Vector3 (rNum, -5 - (Random.Range (0, 100) / 100), 0), Quaternion.identity);
				}
				if (armList [armI] == cartoonArm) {
						cartoonArm.GetComponent<CartoonArm> ().buttCheek = tmpButtCheek;
						cartoonArm.GetComponent<CartoonArm> ().mainAss = this.gameObject;
						Instantiate (armList [armI], new Vector3 (rNum, -5 - (Random.Range (0, 100) / 100), 0), Quaternion.identity);
				}
				if (armList [armI] == boxingArm) {
						boxingArm.GetComponent<BoxingArm> ().buttCheek = tmpButtCheek;
						boxingArm.GetComponent<BoxingArm> ().mainAss = this.gameObject;
						Instantiate (armList [armI], new Vector3 (rNum, -5 - (Random.Range (0, 100) / 100), 0), Quaternion.identity);
				}
								/*int armType = Random.Range(0,GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().activeHands);
			if (armType == 0) {
				arm.GetComponent<ArmScript>().buttCheek = tmpButtCheek;
				arm.GetComponent<ArmScript>().mainAss = this.gameObject;
				arm.GetComponent<ArmScript>().armColorOn = true;
				Instantiate (arm,new Vector3(rNum,-5-(Random.Range(0,100)/100),0), Quaternion.identity);
			}
			if (armType == 1) {
				boxingArm.GetComponent<BoxingArm>().buttCheek = tmpButtCheek;
				boxingArm.GetComponent<BoxingArm>().mainAss = this.gameObject;
				Instantiate (boxingArm,new Vector3(rNum,-5-(Random.Range(0,100)/100),0), Quaternion.identity);
			}
			if (armType == 2) {
				cartoonArm.GetComponent<CartoonArm>().buttCheek = tmpButtCheek;
				cartoonArm.GetComponent<CartoonArm>().mainAss = this.gameObject;
				Instantiate (cartoonArm,new Vector3(rNum,-5-(Random.Range(0,100)/100),0), Quaternion.identity);
			}*/
				counter = 0;
				ScorePoints.text = "" + points;
			}
			//HealthContent.transform.position += new Vector3(-0.05f,0,0);
			if (HealthContent.transform.localScale.x == 0) {
				GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().currentMoney = points;
				GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney += points;
				Application.LoadLevel ("EndScreen");
			}
			}
		if (mode == "grab") {
			//counter2 += 0.1f;
			Vector3 dir = newGrabPos-transform.position;
			transform.position += timeFix*dir*0.5f;
			HealthContent.transform.parent.gameObject.SetActive(false);
			ScoreText.GetComponent<Renderer>().enabled = false;
			ScorePoints.GetComponent<Renderer>().enabled = false;
			countDown -= timeFix*1;
			grabTimer.text = ""+Mathf.Floor(countDown/100)+":"+Mathf.Floor(countDown%100);
			if (ChristmasDeco.activeSelf) {
				ChristmasDeco.GetComponent<AudioSource>().pitch += timeFix*0.0005f;
			}
			if (countDown>500 && countDown<=1000) {
				grabTimer.color = new Color(230/256f,204/256f,74/256f,grabTimer.color.a);
			}
			if (countDown<=500) {
				grabTimer.color = new Color(228/256f,90/256f,90/256f,grabTimer.color.a);
			}
			if (countDown<=0) {
				GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().grabScore = grabCounterScore;
				Application.LoadLevel ("EndScreenGrab");
			}
		}
	}
	public void assGettingGrabbed(float damage) {
		if (HealthContent.transform.localScale.x > 0) {
			HealthContent.transform.localScale += new Vector3 (-damage, 0, 0);
		}
		if (HealthContent.transform.localScale.x<0) {
			HealthContent.transform.localScale = new Vector3 (0,HealthContent.transform.localScale.y,HealthContent.transform.localScale.z);
		}
	}
	void OnMouseDown() {
		if (mode == "grab") {
			GetComponent<AudioSource>().PlayOneShot(GrabThatAss,10f);
			int randI = Random.Range (-5,4);
			newGrabPos = new Vector3((float)randI,transform.position.y,transform.position.z);
			Vector3 mousePos = myCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
			GameObject tmpGrabCounter = (GameObject)Instantiate(grabCounter,new Vector3(mousePos.x,mousePos.y,-8),Quaternion.identity);
			grabCounterScore ++;
			tmpGrabCounter.GetComponent<grabCounterScript>().textCount = grabCounterScore;
			//transform.position = new Vector3((float)randI,transform.position.y,transform.position.z);
		}
	}
}
