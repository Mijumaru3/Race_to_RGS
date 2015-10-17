using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//public variables
	public float speed;
	public float maxSpeed = 5f;
	public float jumpForce;
	public GameObject projectile;

	//private variables
	Rigidbody2D rb;
	float horiz = 0f;
	bool jump = false;
	bool left = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//shooting
		if (Input.GetKeyDown (KeyCode.F)) {
			Fire ();
		}

		//move
		horiz = Input.GetAxis ("Horizontal");

		//press jump key
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}

		//determine if character is facing left or right
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			left = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			left = false;
		}
	}

	void FixedUpdate()
	{
		//jump
		if (jump == true) {
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		//general moving
		rb.AddForce (Vector2.right * horiz * speed);
		if (Mathf.Abs (rb.velocity.x) > maxSpeed) 
		{
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
		}
	}

	//custom functions
	void Fire()
	{	
		BulletScript.left = left;  //set the left variable for bullets so they shoot in right direction
		Vector3 spawnPosition = this.transform.position;  //set the spawn position for the bullet
		if (left) {
			spawnPosition.x -= 0.1f;
		}
		else {
			spawnPosition.x += 0.1f;
		}

		Instantiate (projectile, spawnPosition, Quaternion.identity);  //spawn the bullet
	}
}
