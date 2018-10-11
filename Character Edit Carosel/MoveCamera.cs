using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	private int position;
	float smooth = 2.0f;
	float x1 = -0.06f;
	float y1 = 1.02f;
	float z1 = 8.28f;
	float x2 = -0.0513f;
	float y2 = .53735f;
	float z2 = 7.02163f;
	float b = 0.2f;
	Quaternion original = Quaternion.Euler(35, 181, 0);
	Quaternion nextl = Quaternion.Euler(0, 180, 0);

	// Use this for initialization
	void Start () {
		//transform.position = Vector3.Lerp(this.transform.position, new Vector3(x1,y1,z1), b);
		//transform.rotation = Quaternion.Slerp(this.transform.rotation, original, Time.deltaTime * smooth);
		position = 0;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void MoveC()
	{
		if (position == 0) {
			transform.position = new Vector3(x1,y1,z1);
			//transform.position = Vector3.Lerp(this.transform.position, new Vector3(x2,y2,z2), b);
			transform.rotation = Quaternion.Euler(35, 181, 0);
			//transform.rotation = Quaternion.Slerp(this.transform.rotation, nextl, Time.deltaTime * smooth);
			position = 1;
		} 
		else {
			//transform.position = Vector3.Lerp(this.transform.position, new Vector3(x1,y1,z1), b);
			transform.position = new Vector3(x2,y2,z2);
			transform.rotation = Quaternion.Euler (0, 180, 0);
			//transform.rotation = Quaternion.Slerp(this.transform.rotation, original, Time.deltaTime * smooth);
			position = 0;
		}
	}
}
