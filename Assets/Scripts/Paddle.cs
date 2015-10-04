using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	float units_pos_x = 0.0f;
	// Use this for initialization

	private float limit_spacing = 1.1f;
	private int num_units = 16;

	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		units_pos_x = (Input.mousePosition.x / Screen.width) * num_units;
		float limited_range_x = Mathf.Clamp(
			units_pos_x,
			limit_spacing,
			num_units - limit_spacing
		);

		Vector3 paddle_pos = new Vector3 (
			limited_range_x,
			this.transform.position.y,
			0f
		);

		this.transform.position = paddle_pos;
	}
}
