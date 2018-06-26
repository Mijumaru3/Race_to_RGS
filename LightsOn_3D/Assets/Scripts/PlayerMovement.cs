using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// VARIABLES

	// ground check variables
	/*
	public float _hit_distance;
	public LayerMask _layer_mask;*/
	private bool _is_grounded = true;

	// movement variables
	private float _speed = 10f;
	private float _jump_force = 10f;
	private Vector3 movement = Vector3.zero;

	// component variables
	private Animator _animator;
	private Rigidbody _rb;
	private Collider _collider;

	// UNITY FUNCTIONS

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_rb = GetComponent<Rigidbody> ();
		_collider = GetComponentInChildren<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_animator == null) {
			Debug.Log ("No animator on gameobject");
			return;
		}

		// movement
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (horizontal, 0.0f, vertical);
		if(movement != Vector3.zero)
		{
			_animator.SetBool ("Input", true);
		}
		else
		{
			_animator.SetBool ("Input", false);
		}
		/*
		// jumping
		if(_is_grounded)
		{
			_hit_distance = 0.35f;
		}
		else
		{
			_hit_distance = 0.15f;
		}

		if(Physics.Raycast(transform.position - new Vector3(0, 0.85f, 0), -transform.up, _hit_distance, _layer_mask))
		{
			_is_grounded = true;
		}
		else
		{
			_is_grounded = false;
		}*/
	}

	void FixedUpdate()
	{

		_rb.velocity = movement * _speed;

		if(movement != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log (Physics.Raycast (transform.position, Vector3.down, 10f));
			//Grounded ();
			//_rb.AddForce (Vector3.up * _jump_force);
			//_rb.AddForce (Vector3.up * _jump_force, ForceMode.Impulse);
			_rb.AddForce (transform.up * _jump_force, ForceMode.Impulse);
			//_rb.velocity += new Vector3(0, 30.0f, 0) + (3.0f * gameObject.transform.forward);
			//_rb.AddForce(Vector3.up * _jump_force, ForceMode.VelocityChange);
		}
	}
		
	// CUSTOM FUNCTIONS

	// check if there is a collider below the player character
	private bool Grounded()
	{
		/*
		Debug.DrawRay(transform.position, Vector3.down, Color.green);
		if(Physics.Raycast (transform.position, Vector3.down, _collider.bounds.extents.y))
		{
			return true;
		}

		return false;
		*/

		Vector3 ray_origin = _collider.bounds.center;
		float ray_distance = _collider.bounds.extents.y + 0.1f;

		Ray ray = new Ray ();
		ray.origin = ray_origin;
		ray.direction = Vector3.down;

		if(Physics.Raycast(ray, ray_distance, 1 << 8))
		{
			Debug.Log ("Jump");
			_rb.AddForce(Vector3.up * _jump_force, ForceMode.VelocityChange);
			return true;
		}

		return false;
	}

	public void OnCallChangeFace()
	{
	}
}
