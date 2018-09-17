using UnityEngine;
using System.Collections;

public class GeneralSpawnScript : MonoBehaviour {

	public GameObject General;
	public Camera camera;
	public Transform target;
	// Use this for initialization
	void Start () {
		if (GameObject.Find ("General(Clone)") == null) {
			GameObject tmpGeneral = (GameObject)Instantiate (General, transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
