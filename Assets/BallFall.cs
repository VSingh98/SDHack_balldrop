using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class BallFall : MonoBehaviour {

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;
	
	/// <summary>
	/// Old Code
	/// </summary>
	
	public GameObject myBall;
	
	public static int score = 0;
	public static int life = 3;
	public static bool gameOver = false;
	
	public static bool gameStarted;
	public static bool fist;
	
	public Text scoreText;
	public Text livesText;
	/// <summary>
	/// Old Code
	/// </summary>
	
	void Awake() {
		gameStarted = false;
		fist = false;
	}
	
	// Use this for initialization
	// This method is old code
	void Start () {
		//myBall = gameObject;
//		if(gameStarted) {
			InvokeRepeating ("CloneDrop", 3.0f, 5.0f);
//		}
		
	}
	
	// Update is called once per frame
	// this method is all new code
	void Update () {
	
		Debug.Log ("BallFall script is being called");
		scoreText.text = score.ToString();
		livesText.text = life.ToString();
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			Debug.Log ("We are in big if clause of update method of BallFall");
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.DoubleTap) {
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}
		
		if (BallFall.life <= 0){
			CancelInvoke("CloneDrop");
		}
	}

	void CloneDrop(){
		if(!gameStarted) return;
		GameObject cloneBall = (GameObject)Instantiate(myBall, new Vector3(0, 15, 0), Quaternion.identity);
		cloneBall.GetComponent<SpriteRenderer> ().color = this.getRandomColor();
	}

	//getRandomColor 
	Color getRandomColor(){
		int colornum = Random.Range (0, 3);
		switch (colornum) {
		case 0:
			return Color.red;
		case 1:
			return Color.black;
		case 2:
			return Color.yellow;
		default:
			return Color.white;
		}
	}
	
	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	// New Code
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
}
