using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level load requested for " + name);
		Brick.resetBrickStatus();
		Application.LoadLevel(name);
	}

	public void QuitGame(){
		Debug.Log("Quit game");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Brick.resetBrickStatus();
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if(Brick.breakable_count <= 0){
			Brick.resetBrickStatus();
			LoadNextLevel();
		}
	}

}
