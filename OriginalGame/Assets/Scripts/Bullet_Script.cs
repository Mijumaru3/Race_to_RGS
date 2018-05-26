using UnityEngine;
using System.Collections;

//store the bullet type and handle collision with killzone

public class Bullet_Script : MonoBehaviour {

	/*For materials array:
	 * 0 = rubber
	 * 1 = ice
	 * 2 = sponge
	 * 3 = water
	 */
	
	//public variables
	public int type = 0;  //what type of material the bullet will use

	//========================================================================================================================
	//Unity defined functions

	void OnCollisionEnter2D(Collision2D col)
	{
		//when the bullet collides with the killzone delete the bullet
		if (col.gameObject.tag == "Killzone") {
			Destroy(gameObject);
		}
	}

	//==========================================================================================================================
	//Programmer defined functions

	//public functions

	//return the type of the bullet
	public int GetBulletType()
	{
		return type;
	}
}
