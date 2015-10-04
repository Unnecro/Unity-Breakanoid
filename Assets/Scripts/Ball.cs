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
				float kick_x = limitKick();
				float kick_y = 7.5f;

				this.GetComponent<Rigidbody2D>().velocity = new Vector2(kick_x, kick_y);

				is_game_started = true;
			}
		} else {
			Vector2 velocity = normalizeVelocity(GetComponent<Rigidbody2D>().velocity);
			GetComponent<Rigidbody2D>().velocity = velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));

		if(is_game_started){
			GetComponent<Rigidbody2D>().velocity += tweak;
			GetComponent<AudioSource>().Play();
		}
	}

	Vector2 normalizeVelocity(Vector2 current_velocity){
		float x = current_velocity.x;
		if(current_velocity.x < 2f && current_velocity.x > -2f){
			x *= 2;
		}
		
		float y = current_velocity.y;
		if(current_velocity.y < 2f && current_velocity.y > -2f){
			y *= 2;
		}

		Vector2 velocity = new Vector2(x, y); 

		return velocity;
	}

	float limitKick(){
		float first_kick_x = Random.Range(-10f, 10f);
		float min_range;
		float max_range;
		if(first_kick_x <= 0){
			min_range = -10f;
			max_range = -3f;
		} else {
			min_range = 3f;
			max_range = 10f;
		}

		first_kick_x = Mathf.Clamp(first_kick_x, min_range, max_range);

		return first_kick_x;
	}

	public void resetPosition(){
		is_game_started = false;
		this.transform.position = paddle.transform.position + paddle_to_ball_v3;
	}
}
