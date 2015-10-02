using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hit_sprites;
	public AudioClip audio_break;
	public int audio_break_volume = 1;

	public static int breakable_count = 0;

	private LevelManager levelManager; 

	private int max_hits;
	private int times_hit;
	private bool is_breakable;

	// Use this for initialization
	void Start () {
		is_breakable = (this.tag == "Breakable");
		if(is_breakable){
			breakable_count++;
		}

		times_hit = 0;
		max_hits = hit_sprites.Length + 1;

		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(is_breakable){
			HandleHits();
		}	
	}

	void HandleHits(){
		this.times_hit++;

		if(times_hit >= max_hits){
			AudioSource.PlayClipAtPoint(audio_break, transform.position, audio_break_volume);
			breakable_count--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}

		// if(max_hits == times_hit){
		// 	this.transform.position = new Vector3(this.transform.position.x, 1000f, this.transform.position.y);
		// }
	}

	void LoadSprites(){
		int sprite_index = times_hit - 1;

		if(hit_sprites[sprite_index]){
			this.GetComponent<SpriteRenderer>().sprite = hit_sprites[sprite_index];
		}
	}

	public static void resetBrickStatus(){
		Brick.breakable_count = 0;
	}
}
