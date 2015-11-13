using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	/*For materials array:
	 * 0 = rubber
	 * 1 = ice
	 * 2 = sponge
	 * 3 = water
	 */
	
	//public variables
	public int type = 0;  //what type of material the bullet will use

	// Use this for initialization
	void Start()
	{

	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Killzone") {
			Destroy(gameObject);
		}
	}

	//public function - can be accessed by another script
	public int 	Type()
	{
		return type; //return the type of the bullet
	}
}
