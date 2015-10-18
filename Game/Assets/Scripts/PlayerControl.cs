using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//public variables
	public float speed; //speed of the player
	public float maxSpeed = 5f; //maximum speed of the player
	public float jumpForce; //contorls how high the player will jump
	public GameObject projectile; //what the player will shoot

	//private variables
	Rigidbody2D rb; //rigidbody of the player
	float horiz = 0f; //the value of the horizontal axis
	bool jump = false; //whether the player is jumping or not 
	bool left = false; //whether the player is facing left or not

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> (); //get reference to the rigidbody of the player
	}
	
	// Update is called once per frame
	void Update () {
		//shooting
		//if key F is pressed - call Fire function to fire bullet
		if (Input.GetKeyDown (KeyCode.F)) {
			Fire ();
		}

		//move
		horiz = Input.GetAxis ("Horizontal"); //get value of horizontal access

		//press jump key
		//if space is pressed set jump to true so you can jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}

		//determine if character is facing left or right
		//if the left arrow or a is pressed then the player is going left - so left is true
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			left = true;
		}

		//if the right arrow or d is pressed then the player is going right - so left is false
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			left = false;
		}
	}

	//used fixed update for changes to physics
	void FixedUpdate()
	{
		//jump
		if (jump == true) {
			rb.AddForce(new Vector2(0f, jumpForce)); //if jump is true then add a force in the y direction to the player
			jump = false; //set jump to false so that not continuously adding the upward force
		}

		//general moving
		rb.AddForce (Vector2.right * horiz * speed); //add a force to the player in the x direction
		if (Mathf.Abs (rb.velocity.x) > maxSpeed)  //if the player's speed is more than the maximum speed:
		{
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y); //set the speed back to the maximum
		}
	}

	//custom functions
	//private function by default
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
