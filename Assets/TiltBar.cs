using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class TiltBar : MonoBehaviour {

	public GameObject myo = null;	//made static
	
	private GameObject myBar;		//made static
	// Use this for initialization
	void Start () {
		myBar = gameObject;
	}
	
	// Update is called once per frame
	//If a or d key is pressed tilt the bar by 10 degrees around the z axis.

   /*
    * Purpose: To update the paddles with every frame refresh
    *          When space bar is pressed, paddles expand out.
    *          When 'b' is pressed, paddles come in.
    */
	void Update () {
		// Access the ThalmicMyo component attached to the Myo object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		//myo.GetComponent<ThalmicMyo> ();
		
		if (thalmicMyo.pose == Pose.WaveOut) {
			Debug.Log("Wave out");
			myBar.transform.Rotate (0, 0, -2);
		}
		
		if (thalmicMyo.pose == Pose.WaveIn) {
			Debug.Log("Wave in");
			myBar.transform.Rotate (0, 0, 2);
		}
		
		if (thalmicMyo.pose == Pose.Fist) {
			Debug.Log("Rest");
			myBar.transform.Rotate (0, 0, 0);
			BallFall.fist = true;
		}
		
		
		
		if (Input.GetKey("d")) {
			myBar.transform.Rotate (0, 0, -5);
		} else if (Input.GetKey("a")) {
			myBar.transform.Rotate (0, 0, 5);
		}



	}
}
