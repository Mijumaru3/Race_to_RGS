using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// VARIABLES

	// ground check variables
	private bool _in_air = false;
	private bool _jump = false;

	// movement variables
	private float _speed = 10f;
	private float _jump_force = 7f;
	private Vector3 movement = Vector3.zero;

	// component variables
	//private Animator _animator;
	private Rigidbody _rb;
	private Collider _collider;

	// UNITY FUNCTIONS

	// Use this for initialization
	void Start () {
		//_animator = GetComponent<Animator> ();
		_rb = GetComponent<Rigidbody> ();
		_collider = GetComponentInChildren<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		// movement
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (horizontal, 0.0f, vertical);

		/*
		if(movement != Vector3.zero)
		{
			_animator.SetBool ("Input", true);
		}
		else
		{
			_animator.SetBool ("Input", false);
		}
		*/

		// jumping
		if(Input.GetKeyDown(KeyCode.Space))
		{
			_jump = true;
		}
	}

	void FixedUpdate()
	{
		if(!_in_air)
		{
			_rb.velocity = movement * _speed;

			/*
			 * rotate to match the direction of movement
			if(movement != Vector3.zero)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
			}
			*/


			if (_jump)
			{
				//_rb.AddForce (Vector3.up * _jump_force);
				_rb.AddForce (Vector3.up * _jump_force, ForceMode.Impulse);
				//_rb.AddForce (transform.up * _jump_force, ForceMode.Impulse);
				//_rb.velocity += new Vector3(0, _jump_force, 0) + (3.0f * gameObject.transform.forward);
				_jump = false;
				_in_air = true;
				//_rb.AddForce(Vector3.up * _jump_force, ForceMode.VelocityChange);
			}			
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Platform")
		{
			Vector3 direction = gameObject.transform.position - col.gameObject.transform.position;
			direction.Normalize ();
			//Debug.Log (direction.y);

			if(direction.y > 0)
			{
				_in_air = false;
			}
		}
	}
}
