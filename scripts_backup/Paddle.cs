using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float units_pos_x = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		units_pos_x = (Input.mousePosition.x / Screen.width) * 16;
		Vector3 paddle_pos = new Vector3(Mathf.Clamp(units_pos_x, 0.7f, 15.3f), this.transform.position.y, 0f);

		this.transform.position = paddle_pos;
	}
}
