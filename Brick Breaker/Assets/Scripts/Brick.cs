using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	private LevelMananger level_mananger;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		level_mananger = GameObject.FindObjectOfType<LevelMananger>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void OnCollisionEnter2D (Collision2D collision){
		timesHit++;
		if(timesHit >= maxHits){
			Destroy(gameObject);
		}
	}
	
	// TODO -> Remove this method once win funcionality is maid
	void SimulateWin(){
		level_mananger.LoadNextLevel();
	}
}
