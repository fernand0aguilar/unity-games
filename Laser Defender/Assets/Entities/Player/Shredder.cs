using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		print("triggered");
		Destroy(col.gameObject);
	}
}
