using UnityEngine;
using System.Collections;

public class TiltBar : MonoBehaviour {

	private GameObject myBar;
	// Use this for initialization
	void Start () {
		myBar = gameObject;
	}
	
	// Update is called once per frame
	//If a or d key is pressed tilt the bar by 10 degrees around the z axis.
	void Update () {

		if (Input.GetKey("d")) {
			myBar.transform.Rotate (0, 0, 10);
		} else if (Input.GetKey("a")) {
			myBar.transform.Rotate (0, 0, -10);
		}


	}
}
