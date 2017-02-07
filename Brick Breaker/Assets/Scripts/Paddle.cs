using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		
		if (! autoPlay){
			moveWithMouse();
		}
		else{
			AutoPlayEnable();
		}
		
		
	}
	void moveWithMouse(){
	
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		
		this.transform.position = paddlePos;
	
	}
	
	void AutoPlayEnable(){
		Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		
		paddlePosition.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);
		
		this.transform.position = paddlePosition;
	}
}
