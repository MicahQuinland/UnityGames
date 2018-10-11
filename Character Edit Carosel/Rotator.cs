using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private float speed;
	private int now;

	public void Spin()
	{
		if (now % 2 == 0) {
			speed = 0f;
		} 
		else {
			speed = 90f;
		}
		now++;
	}

	// Use this for initialization
	void Start () {
		speed = 90f;
		now = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
