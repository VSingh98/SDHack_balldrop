using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	Animator anim;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Awake(){
		anim = GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	void Update () {
			
		if(BallFall.gameStarted && /*Input.anyKey*/ BallFall.fist){
			anim.SetTrigger("GameStart");
		}
	}
}
