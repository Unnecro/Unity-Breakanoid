using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour {

	static public int retries;
	static List<GameObject> list_lives = new List<GameObject>(); 

	[Range(0.5f, 3f)]
	public float lives_spacing = 0.8f;
	// Use this for initialization
	void Start () {
		drawLives();
	}
	
	void drawLives(){
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float z = this.transform.position.z;
		int live_count = 0;
		for(int i = retries; i > 0; i--){
			live_count++;
			GameObject go = new GameObject();
			go.name = "Live_" + live_count.ToString(); 
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();

			renderer.sprite = Resources.Load("live", typeof(Sprite)) as Sprite;
			go.transform.position = new Vector3(x, y, z);
			list_lives.Add(go);

			x += lives_spacing;
		}
	}

	static public void removeLiveSprite(){
		Destroy(list_lives[retries]);
		list_lives.RemoveAt(retries);
	}

	static public void clearLives(){
		list_lives.Clear();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
