using UnityEngine;
using System.Collections;

public class EyelidScript : MonoBehaviour {
	public int direction;
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		speed *= 1.05f;
		transform.position += new Vector3 (0,speed*direction,0);
	}
}
