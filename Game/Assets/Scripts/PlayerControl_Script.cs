using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl_Script : MonoBehaviour {

	//variables that have to do with movement speed
	public float speed;  //speed of the player
	public float maxSpeed = 5f;  //maximum speed of the player
	Rigidbody2D rb;  //rigidbody of the player
	float horiz = 0f;  //the value of the horizontal axis

	//variables that have to do with jumping
	public float jumpForce;  //contorls how high the player will jump
	bool jump = false;  //whether the player is jumping or not
	int numJumps= 0;  //how many jumps the player is allowed to have

	//variables that have to do with the bullets
	public float bulletSpeed = 4f;
	public GameObject[] projectiles;  //array of what the player can shoot
	int proj_num = 0;  //decides which projectile to shoot from the array

	//variables that have to do with knockback when running into enemeies
	public float knockbackTime;
	public float knockbackForce;
	public float knockbackCount;
	public bool knockbackFromRight;

	//variables that deal with the game controller
	GameObject gameController;
	GameControl_Script gc_s;
	BulletTypeDisplay_Script btd_s;
	Switch_Script sw_s;

	//other variables
	float currentHealth;

	//===================================================================================================================================
	//Unity Functions
	// Use this for initialization
	void Start () {
		//get different scripts of the game controller object
		gameController = GameObject.Find ("GameController");
		gc_s = gameController.GetComponent<GameControl_Script>();
		btd_s = gameController.GetComponent<BulletTypeDisplay_Script>();
		sw_s = gameController.GetComponent<Switch_Script>();

		//get reference to the rigidbody of the player
		rb = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
		//-------------------------------------------------------------------------------------------------------------------------------
		//Stuff to do with shooting
		//if left mouse button is pressed - call Fire function to fire bullet
		if (Input.GetMouseButtonDown (0)) {
			Shoot ();
		}
		//goes through the bullets in the array every time the right mouse button is pressed
		if (Input.GetMouseButtonDown (1)) {
			proj_num++;
			if(proj_num >= projectiles.Length) //if the proj_numb is more than or equal to the length of the projectiles array
			{
				proj_num = 0;  //then reset the proj_num to the beginning of the array
			}

			btd_s.ChangeBulletImage(proj_num);
		}

		//---------------------------------------------------------------------------------------------------------------------------------
		//Stuff to do with moving
		horiz = Input.GetAxis ("Horizontal"); //get value of horizontal access

		//press jump key
		//if space is pressed set jump to true so you can jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}
	}

	//used fixed update for changes to physics
	void FixedUpdate()
	{
		if(knockbackCount <= 0)
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
		else
		{
			//when the player collides with an enemy knock player back a bit (don't let player move during the time of knockback)
			if(knockbackFromRight)
			{
				rb.velocity = new Vector2(-knockbackForce, 1f);
			}
			else
			{
				rb.velocity = new Vector2(knockbackForce, 1f);
			}
			knockbackCount -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//if the player hits the killzone then bring it back to the beginning position
		if (col.gameObject.tag == "Killzone") {
			gc_s.Respawn();
			gc_s.ChangeHealth(10);
		}

		//once the player lands numJumps is reset
		if (col.gameObject.tag == "block") {
			numJumps = 0;
		}

		//when player collides with the switch turn on the lights
		if (col.gameObject.tag == "Switch") {
			sw_s.TurnOn();
		}

		//when player collides with the open doors then the player has won
		if(col.gameObject.tag == "Doors")
		{
			gc_s.ReachDoors();
		}
	}

	//========================================================================================================================================
	//custom functions
	//private function by default
	void Shoot()
	{
		//find the mouse position and calculate direction to shoot in baesd on that
		Vector3 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 direction = target - transform.position;
		direction.Normalize ();

		//store the place at which to spawn the bullet
		Vector3 playerPos = new Vector3 (transform.position.x + (direction.x), transform.position.y + (direction.y), transform.position.z);

		//create the bullet and give it the proper direction to go in and a speed
		GameObject bullet = (GameObject)Instantiate (projectiles [proj_num], playerPos, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
	}
}
