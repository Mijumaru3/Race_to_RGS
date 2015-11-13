using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	//public variables
	public float speed; //speed of the player
	public float maxSpeed = 5f; //maximum speed of the player
	public float jumpForce; //contorls how high the player will jump
	public float bulletSpeed = 4f;
	public GameObject[] projectiles; //array of what the player can shoot

	public int health = 100; //amount of health the player has

	//private variables
	Rigidbody2D rb; //rigidbody of the player
	float horiz = 0f; //the value of the horizontal axis

	bool jump = false; //whether the player is jumping or not
	int numJumps= 0; //how many jumps the player is allowed to have
	int proj_num = 0; //decides which projectile to shoot from the array

//	bool left = false; //whether the player is facing left or not
	Vector3 startPosition; //stores the starting position of the ball

	//===================================================================================================================================
	//Unity Functions
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> (); //get reference to the rigidbody of the player
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//-------------------------------------------------------------------------------------------------------------------------------
		//Stuff to do with shooting
		//if left mouse button is pressed - call Fire function to fire bullet
		if (Input.GetMouseButtonDown(0)) {
			Shoot();
		}

		//goes through the bullets in the array every time the right mouse button is pressed
		if (Input.GetMouseButtonDown (1)) {
			proj_num++;
			if(proj_num >= projectiles.Length) //if the proj_numb is more than or equal to the length of the projectiles array
			{
				proj_num = 0;  //then reset the proj_num to the beginning of the array
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------------
		//Stuff to do with moving
		horiz = Input.GetAxis ("Horizontal"); //get value of horizontal access

		//press jump key
		//if space is pressed set jump to true so you can jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}

		/*
		//determine if character is facing left or right
		//if the left arrow or a is pressed then the player is going left - so left is true
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
			left = true;
		}

		//if the right arrow or d is pressed then the player is going right - so left is false
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
			left = false;
		}*/
	}

	//used fixed update for changes to physics
	void FixedUpdate()
	{
		//jump
		if (jump == true && numJumps == 0) {
			rb.AddForce(new Vector2(0f, jumpForce)); //if jump is true then add a force in the y direction to the player
			numJumps++;
			jump = false; //set jump to false so that not continuously adding the upward force
		}

		//general moving
		rb.AddForce (Vector2.right * horiz * speed); //add a force to the player in the x direction
		if (Mathf.Abs (rb.velocity.x) > maxSpeed)  //if the player's speed is more than the maximum speed:
		{
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y); //set the speed back to the maximum
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		//if the player hits the killzone then bring it back to the beginning position
		if (col.gameObject.tag == "Killzone") {
			transform.position = startPosition;
		}

		//once the player lands numJumps is reset
		if (col.gameObject.tag == "block") {
			numJumps = 0;
		}
	}

	//========================================================================================================================================
	//custom functions
	//private function by default
	void Shoot()
	{
		Vector3 direction = Input.mousePosition;
		direction.z = 0.0f;
		direction = Camera.main.ScreenToWorldPoint (direction);
		Vector3 playerPos = new Vector3 (transform.position.x + (direction.x / 10), transform.position.y + (direction.y / 10), transform.position.z);
		direction = direction - transform.position;
		GameObject bul = (GameObject) Instantiate (projectiles [proj_num], playerPos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		bul.GetComponent<Rigidbody2D>().velocity = new Vector2 (direction.x * bulletSpeed, direction.y * bulletSpeed);
	}

	//public function - can be called from other objects
	//decreases the health of the player by however much damage is given as an argument to the function
	public void decreaseHealth(int damage)
	{
		health -= damage;
	}
}
