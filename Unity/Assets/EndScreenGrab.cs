using UnityEngine;
using System.Collections;

public class EndScreenGrab : MonoBehaviour {

	int bestGrabScore;
	int currentGrabScore;
	bool newBest = false;
	public int counter = 0;
	public TextMesh currentScoreLabel;
	public TextMesh currentScoreText;
	public TextMesh bestScoreLabel;
	public TextMesh bestScoreText;
	public TextMesh newBestText;
	// Use this for initialization
	void Start () {
		currentGrabScore = GameObject.Find ("General(Clone)").GetComponent<GeneralScript> ().grabScore;
		Debug.Log (currentGrabScore);
		if (PlayerPrefs.HasKey("bestGrabScore")) {
			bestGrabScore = PlayerPrefs.GetInt("bestGrabScore");
			if (currentGrabScore>bestGrabScore) {
				bestGrabScore = currentGrabScore;
				newBest = true;
				PlayerPrefs.SetInt("bestGrabScore",currentGrabScore);
			}
		} else {
			PlayerPrefs.SetInt("bestGrabScore",currentGrabScore);
		}
		currentScoreText.text = ""+currentGrabScore;
		bestScoreText.text = ""+bestGrabScore;
		currentScoreLabel.GetComponent<Renderer>().enabled = false;
		currentScoreText.GetComponent<Renderer>().enabled = false;
		bestScoreLabel.GetComponent<Renderer>().enabled = false;
		bestScoreText.GetComponent<Renderer>().enabled = false;
		newBestText.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter ++;
		if (counter > 100) {
			currentScoreLabel.GetComponent<Renderer>().enabled = true;
			currentScoreText.GetComponent<Renderer>().enabled = true;
		}
		if (counter > 150 && newBest) {
			newBestText.GetComponent<Renderer>().enabled = true;
		}
		if (counter > 200) {
			bestScoreLabel.GetComponent<Renderer>().enabled = true;
			bestScoreText.GetComponent<Renderer>().enabled = true;
		}
	}
}
