using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	
	private Vector3 paddle_to_ball_v3;

	// Use this for initialization
	void Start () {
		paddle_to_ball_v3 = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = paddle.transform.position + paddle_to_ball_v3;

		if(Input.GetMouseButtonDown(0)){
			print("Moues is clicked");

			this.rigidbody2D.velocity = new Vector2(2f, 10f);
		}
	}
}
