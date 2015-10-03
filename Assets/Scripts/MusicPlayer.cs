using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization

	static MusicPlayer Self;
	static bool is_playing = false;

	void Awake(){
		if(Self){
			DestroyImmediate(this.gameObject);
		} else {
			Self = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}

		if(Self.GetComponent<AudioSource>().playOnAwake){
			is_playing = true;
		}
	}

	void Start () {

	}

	void Update() {
		if(Input.GetKeyDown("v")){
			if(is_playing){
				GetComponent<AudioSource>().Pause();
			} else {
				GetComponent<AudioSource>().Play();	
			}

			is_playing = !is_playing;
		}
	}

}
