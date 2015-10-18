using UnityEngine;
using System.Collections;

public class ChangeMat : MonoBehaviour {

	//public variables
	public PhysicsMaterial2D[] mats; //array of materials of the block

	//private variables
	Collider2D col; //collider of the block
	PhysicsMaterial2D current; //the current material of the block
	
	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> (); //get reference to the collider of the block
		current = null; //initialize current material to null - meaning no material in effect
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		//if the game object that collides with the block's collider has the tag "bullet"
		if (obj.gameObject.tag == "bullet") {
			int type = obj.gameObject.GetComponent<BulletScript>().Type(); //get the type of the bullet
			current = mats[type]; //set the variable current based on the type of the bullet
			col.sharedMaterial = current; //set the material of the block to the current material 
			col.enabled = false; //disable block's collider
			col.enabled = true; //then re-enable block's collider to make changes take effect

			Destroy(obj.gameObject);
		}
	}
}
