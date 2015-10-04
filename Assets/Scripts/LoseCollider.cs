using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	[Range(0, 10)]
	public int max_retries = 3;
	private int retries;
	private Ball ball;

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		ball = GameObject.Find("Ball").GetComponent<Ball>();
		retries = max_retries;
	}

	void OnTriggerEnter2D(Collider2D trigger){
		retries--;
		if(retries <= 0){
			levelManager.LoadLevel("Loose Screen");
		} else {
			ball.resetPosition();
		}
		
	}

}
