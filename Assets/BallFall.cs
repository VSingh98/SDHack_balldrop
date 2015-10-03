using UnityEngine;
using System.Collections;

public class BallFall : MonoBehaviour {

	private GameObject myBall;
	// Use this for initialization
	void Start () {
		myBall = gameObject;
		InvokeRepeating ("CloneDrop", 1.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CloneDrop(){
		GameObject cloneBall = (GameObject)Instantiate(myBall, new Vector3(0, 20, 0), Quaternion.identity);
		cloneBall.GetComponent<SpriteRenderer> ().color = this.getRandomColor();
	}

	//getRandomColor 
	Color getRandomColor(){
		int colornum = Random.Range (0, 3);
		switch (colornum) {
		case 0:
			return Color.red;
		case 1:
			return Color.blue;
		case 2:
			return Color.yellow;
		default:
			return Color.black;
		}
	}
}
