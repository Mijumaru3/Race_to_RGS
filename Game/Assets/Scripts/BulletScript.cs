using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//public variables
	public static bool left; //determines whether or not the bullet should move left;
							//public static used to change the variable in from another script
	public float speed = 4f; //speed of the bullet
	public int type = 0;  //what type of material the bullet will use

	//private variables
	Rigidbody2D rb; //the rigidbody of the bullet (needed to change the forces acting on the bullet)

	// Use this for initialization
	void Start () {

		//set teh initial velocity of the object
		rb = gameObject.GetComponent<Rigidbody2D> ();  //gets a reference to the rigidbody of the bullet
		rb.velocity = new Vector2 (-speed, 0f); //set the initial velocity of the bullet (negative is left - so set initial speed to lef)

		if (left) //if the bullet is suppoesd to go left then:
			speed = -speed; //multiply speed by -1
	}

	//used fixed update for changes in the physics of the object
	void FixedUpdate () {
		rb.velocity = new Vector2(speed, 0f); //apply the speed in the x direction to the bullet
	}

	//public function - can be accessed by another script
	public int 	Type()
	{
		return type; //return the type of the bullet
	}
}
