using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	void Awake(){
		anim = GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(BallFall.life <= 0 ){
			anim.SetTrigger("GameOver");
		}
	}
}
