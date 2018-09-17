using UnityEngine;
using System.Collections;

public class EndScreenScript : MonoBehaviour {

	// Use this for initialization
	public TextMesh totalMoneyLabel;
	public TextMesh totalMoney;
	public GameObject totalCoin;
	public TextMesh currentMoneyLabel;
	public TextMesh currentMoney;
	public GameObject currentCoin;
	public TextMesh bestMoneyLabel;
	public TextMesh bestMoney;
	public GameObject bestCoin;
	public GameObject scoreDivider;
	public GameObject newBestNotifier;
	public int currentMoneyVar;
	public int desiredMoney;
	public int preCounter = 0;
	int counter = 0;
	public int counter2 = 0;
	int bestScore = 0;
	public int extraMoneyVar;
	public TextMesh extraMoney;
	void Start () {
		desiredMoney = GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().currentMoney;
		currentMoneyVar = 0;
		currentMoney.text = currentMoneyVar+"";
		PlayerPrefs.SetInt ("totalScore", GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney);
		bestMoneyLabel.color = new Color (bestMoneyLabel.color.r, bestMoneyLabel.color.g, bestMoneyLabel.color.b,0);
		bestMoney.color = new Color (bestMoney.color.r, bestMoney.color.g, bestMoney.color.b,0);
		if (PlayerPrefs.HasKey("bestScore")) {
			bestScore = PlayerPrefs.GetInt("bestScore");
		}
		totalMoney.text = bestScore+"";
		bestCoin.GetComponent<Renderer>().enabled = false;
		totalMoneyLabel.color = new Color (totalMoneyLabel.color.r, totalMoneyLabel.color.g, totalMoneyLabel.color.b,0);
		totalMoney.color = new Color (totalMoney.color.r, totalMoney.color.g, totalMoney.color.b,0);
		totalMoney.text = GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney-desiredMoney+"";
		totalCoin.GetComponent<Renderer>().enabled = false;
		scoreDivider.GetComponent<Renderer>().enabled = false;
		newBestNotifier.GetComponent<Renderer>().enabled = false;
		extraMoney.GetComponent<Renderer>().enabled = false;
		extraMoneyVar = desiredMoney;
	}
	
	// Update is called once per frame
	void Update () {
		preCounter++;
		if (preCounter < 50) {
			return;
		}
		counter ++;
		if (counter % 3 == 0) {
			if (currentMoneyVar < desiredMoney) {
				currentMoneyVar ++;
			}
			counter = 0;
		}
		if (currentMoneyVar == desiredMoney) {
			counter2 ++;
		}
		if (desiredMoney > bestScore) {
			if (counter2 > 50 && !newBestNotifier.GetComponent<Renderer>().enabled) {
				PlayerPrefs.SetInt ("bestScore",desiredMoney);
				newBestNotifier.GetComponent<Renderer>().enabled = true;
				bestScore = desiredMoney;
				counter2 = 0;
			}
		}
		if (counter2>50) {
			bestMoneyLabel.color = new Color (bestMoneyLabel.color.r, bestMoneyLabel.color.g, bestMoneyLabel.color.b,1);
			bestMoney.color = new Color (bestMoney.color.r, bestMoney.color.g, bestMoney.color.b,1);
			bestCoin.GetComponent<Renderer>().enabled = true;
		}
		if (counter2 > 150) {
			scoreDivider.GetComponent<Renderer>().enabled = true;
		}
		if (counter2 > 200) {
			totalMoneyLabel.color = new Color (totalMoneyLabel.color.r, totalMoneyLabel.color.g, totalMoneyLabel.color.b,1);
			totalMoney.color = new Color (totalMoney.color.r, totalMoney.color.g, totalMoney.color.b,1);
			totalCoin.GetComponent<Renderer>().enabled = true;
		}
		if (counter2 > 250) {
			extraMoney.GetComponent<Renderer>().enabled = true;
		}
		if (counter2 > 300) {
			if (counter % 3 == 0) {
				if (extraMoneyVar > 0) {
					extraMoneyVar --;
				}
			}
		}
		bestMoney.text = bestScore+"";
		currentMoney.text = currentMoneyVar + "";
		extraMoney.text = "+ "+extraMoneyVar + "";
		totalMoney.text = ""+(GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().totalMoney - desiredMoney + (desiredMoney - extraMoneyVar));
	}
}
