using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//public variables
	public static bool left;
	public float speed = 4f;
	public int type = 0;

	//private variables
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		//set teh initial velocity of the object
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (-speed, 0f); 
		
		if (left == false)
		{
			//Vector3 scale = transform.localScale;
			//scale.x *= -1;
			//transform.localScale = scale;
			speed = -speed;
		}
	}
	
	void FixedUpdate () {
		rb.velocity = new Vector2(-speed, 0f);
	}

	public int 	Type()
	{
		return type;
	}
}
