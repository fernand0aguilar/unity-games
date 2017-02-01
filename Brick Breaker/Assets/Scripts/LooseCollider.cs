using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelMananger mananger;
	
	void OnTriggerEnter2D (Collider2D collider){
		mananger = GameObject.FindObjectOfType<LevelMananger>();
		
		mananger.LoadLevel("Loose");
	}
}
