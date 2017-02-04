using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	void start(){
	
	}

	void Update () {
		
		Vector3 paddlePos;
		float mousePosInBlocks;
				
		paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		
		this.transform.position = paddlePos;
		
	}
	
}
