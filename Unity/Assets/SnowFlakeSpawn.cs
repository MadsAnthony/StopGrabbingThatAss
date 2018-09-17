using UnityEngine;
using System.Collections;

public class SnowFlakeSpawn : MonoBehaviour {

	public GameObject snowFlake;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("isChristmas") == 1) {
			for (int i = -6; i<6; i += 2) {
					for (int j = -4; j<4; j++) {
							int randI = Random.Range (0, 10);
							Instantiate (snowFlake, new Vector3 (i+Mathf.Abs(j%2), j + randI * 0.08f, -7), Quaternion.identity);
					}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
