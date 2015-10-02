using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization

	static MusicPlayer Self;

	void Awake(){
		if(Self){
			DestroyImmediate(this.gameObject);
		} else {
			Self = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
	}

	void Start () {

	}

}
