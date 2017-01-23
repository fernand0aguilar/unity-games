using UnityEngine;
using System.Collections;

public class LevelMananger : MonoBehaviour {
	
	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
	public void QuitRequest(){
		Application.Quit();
	}
}
