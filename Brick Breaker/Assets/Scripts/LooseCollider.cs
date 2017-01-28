using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	public LevelMananger mananger;
	
	void OnTriggerEnter2D (Collider2D collider){
		print ("Passou");
		mananger.LoadLevel("Win");
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print ("Colidiu");
	}
}
