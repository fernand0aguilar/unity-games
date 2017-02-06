using UnityEngine;
using System.Collections;

public class LevelMananger : MonoBehaviour {
	
	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		
		//Last Brick destroyed
		if(Brick.breakableCount <= 0){
			LoadNextLevel();	
		}
	}
}
