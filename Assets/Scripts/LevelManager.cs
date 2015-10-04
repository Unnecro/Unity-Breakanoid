using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void Update(){
		if(Input.GetKeyDown("space")){
			LoadNextLevel();
		}
	}

	public void LoadLevel(string name){
		Cursor.visible = true;
		resetGameStatus();
		Application.LoadLevel(name);
	}

	public void QuitGame(){
		Debug.Log("Quit game");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Cursor.visible = true;
		resetGameStatus();
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if(Brick.breakable_count <= 0){
			resetGameStatus();
			LoadNextLevel();
		}
	}

	private void resetGameStatus(){
		Brick.resetBrickStatus();
		HUDManager.clearLives();
	}

}
