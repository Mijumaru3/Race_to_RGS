using UnityEngine;
using System.Collections;

public class ChangeMat : MonoBehaviour {

	//public variables
	public PhysicsMaterial2D[] mats;

	//private variables
	Collider2D col;
	PhysicsMaterial2D current;
	
	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> ();
		current = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "bullet") {
			int type = obj.gameObject.GetComponent<BulletScript>().Type();
			current = mats[type];
			col.sharedMaterial = current;
			col.enabled = false;
			col.enabled = true;

			Destroy(obj.gameObject);
		}
	}
	/*
	public void chooseMat(int i)
	{
		current = mats [0];
		col.sharedMaterial = current;
		col.enabled = false;
		col.enabled = true;
	}*/
}
