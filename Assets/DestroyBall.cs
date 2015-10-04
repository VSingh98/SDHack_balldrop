using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyBall : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//if (gameObject.transform.position.y < lowbar) {
		//	Destroy (gameObject);
		//} 


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("BoxLeft"))
        {
			if(gameObject.GetComponent<SpriteRenderer>().color.Equals(Color.black)){
				BallFall.score += 1;
			}else {BallFall.life --;}
            Destroy(gameObject);
        }
		else if (other.gameObject.name.Equals("BoxRight"))
		{
			if(gameObject.GetComponent<SpriteRenderer>().color.Equals(Color.red)){
				BallFall.score ++;
			}else {BallFall.life --;}
			Destroy(gameObject);
		}
		else if (other.gameObject.name.Equals("BoxBottom"))
		{
			if(gameObject.GetComponent<SpriteRenderer>().color.Equals(Color.yellow)){
				BallFall.score ++;
			} else {BallFall.life --;}
			Destroy(gameObject);
		}
		Debug.Log(BallFall.score);

    }
	

}
