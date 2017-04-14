using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding = 1;
	
	private float xmax = -5;
	private float xmin = 5;
	
	
	// Use this for initialization
	void Start () {
	
		Camera camera = Camera.main;
		
		float distance = transform.position.z - camera.transform.position.z;
		
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,0,distance)).x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x - speed * Time.deltaTime, xmin, xmax),
				transform.position.y,
				transform.position.z
			);
		} else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax),
				transform.position.y,
				transform.position.z
			 );
		}
	}
}
