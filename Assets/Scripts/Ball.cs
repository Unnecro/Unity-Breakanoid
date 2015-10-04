using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddle_to_ball_v3;

	public static float pos_x;

	bool is_game_started = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddle_to_ball_v3 = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		pos_x = this.transform.position.x;
		if(!is_game_started){
			this.transform.position = paddle.transform.position + paddle_to_ball_v3;
			if(Input.GetMouseButtonDown(0)){
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 7.5f);

				is_game_started = true;
			}
		} else {

		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if(is_game_started){
			GetComponent<Rigidbody2D>().velocity += tweak;
			GetComponent<AudioSource>().Play();
		}
	}

	public void resetPosition(){
		is_game_started = false;
		this.transform.position = paddle.transform.position + paddle_to_ball_v3;
	}
}
