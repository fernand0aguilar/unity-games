using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	public Sprite[] hitSprites;
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
		bool isBreakable = (this.tag == "Breakable");
		
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		
		if(timesHit >= hitSprites.Length + 1){
			Destroy(gameObject);
		}
		
		else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	
	void SimulateWin(){
		level_mananger.LoadNextLevel();
	}
}
