using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	void start(){
	
	}

	void Update () {
	
		Vector3 paddlePosition;
		float mousePosInBlocks;
		
		paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
		
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 8;
	
		// Set limits to the paddle inside screen (min 0.5 , max 7.5);
		
		paddlePosition.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 7.5f);
		
		this.transform.position = paddlePosition;
		
		
	}
	
}
