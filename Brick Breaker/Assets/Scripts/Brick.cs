using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit = 0;
	public static int breakableCount = 0;
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	private LevelMananger level_mananger;
	private bool isBreakable;
	
	
	void Start () {
	
		isBreakable = (this.tag == "Breakable");
		
		//Keep Track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		
		level_mananger = GameObject.FindObjectOfType<LevelMananger>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		
		if(timesHit >= hitSprites.Length + 1){
			breakableCount--;
			level_mananger.BrickDestroyed();
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
