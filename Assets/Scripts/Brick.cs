using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hit_sprites;

	public AudioClip audio_break;
	[Range(0.0f, 1.0f)]
	public float break_volume = 0.5f;

	public AudioClip audio_hit;
	[Range(0.0f, 1.0f)]
	public float hit_volume = 0.3f;

	public static int breakable_count = 0;

	private LevelManager levelManager; 

	private int max_hits;
	private int times_hit;
	private bool is_breakable;

	public GameObject smoke;

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
			AudioSource.PlayClipAtPoint(audio_break, Camera.main.transform.position, break_volume);
			breakable_count--;
			levelManager.BrickDestroyed();

			puffSmoke();

			Destroy(gameObject);
		} else {
			AudioSource.PlayClipAtPoint(audio_hit, Camera.main.transform.position, break_volume);
			LoadSprites();
		}
	}

	void puffSmoke(){
		GameObject a = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject; 
		a.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites(){
		int sprite_index = times_hit - 1;

		if(hit_sprites[sprite_index]){
			this.GetComponent<SpriteRenderer>().sprite = hit_sprites[sprite_index];
		} else {
			Debug.LogError(this.name + " is missing sprite");
		}
	}

	public static void resetBrickStatus(){
		Brick.breakable_count = 0;
	}
}
