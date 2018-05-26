using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//deal with changing the material of a platform

public class ChangeMaterial_Script : MonoBehaviour {

	/*For materials array:
	 * 0 = rubber
	 * 1 = ice
	 * 2 = sponge
	 * 3 = water
	 */

	//variables that deal with the materials
	public PhysicsMaterial2D[] mats; //array of materials of the block
	PhysicsMaterial2D current; //the current material of the block
	Collider2D col; //collider of the block

	//variables that deal with changing the sprite
	public Sprite[] sprites; //array of sprites of the block
	SpriteRenderer sp;

	//====================================================================================================================================================
	//Unity defined functions

	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> (); //get reference to the collider of the block
		sp = GetComponent<SpriteRenderer>(); 
		current = null; //initialize current material to null - meaning no material in effect
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		//if the game object that collides with the block's collider has the tag "bullet"
		if (obj.gameObject.tag == "bullet") {
			int type = obj.gameObject.GetComponent<Bullet_Script>().GetBulletType(); //get the type of the bullet
			if(type < 3)
			{
				current = mats[type]; //set the variable current based on the type of the bullet
				col.sharedMaterial = current; //set the material of the block to the current material 
				col.enabled = false; //disable block's collider
				col.enabled = true; //then re-enable block's collider to make changes take effect
				sp.sprite = sprites[type];
			}

			Destroy(obj.gameObject); //destroy the object that collided with the platform
		}
	}
}
