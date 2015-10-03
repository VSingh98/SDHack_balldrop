using UnityEngine;
using System.Collections;

public class DestroyBall : MonoBehaviour {

	private int lowbar = -10;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < lowbar) {
			Destroy (gameObject);
		}
	}
}
