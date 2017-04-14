using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding = 1;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate;
	
	private float xmax = -5;
	private float xmin = 5;
	
	
	// Use this for initialization
	void Start () {
	
		Camera camera = Camera.main;
		
		float distance = transform.position.z - camera.transform.position.z;
		
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,0,distance)).x - padding;
	}
	
	
	void Fire(){
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 1e-9f, firingRate); 
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		
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
