using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// VARIABLES
	private float _speed = 10f;
	private float _rotation_speed = 100f;

	private Animator _animator;
	private Rigidbody _rb;

	// FUNCTIONS

	// Use this for initialization
	void Start () {
		_animator = GetComponentInChildren<Animator> ();
		_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_animator == null) {
			return;
		}

		float in_x = Input.GetAxis ("Horizontal");
		float in_y = Input.GetAxis ("Vertical");

		Move (in_x, in_y);
	}

	private void Move(float x, float y)
	{
		_animator.SetFloat ("VelX", x);
		_animator.SetFloat ("VelY", y);

		/*
		transform.position += Vector3.forward * _speed * y * Time.deltaTime;
		transform.position += Vector3.right * _speed * x * Time.deltaTime;
		*/

		float translation = y * _speed * Time.deltaTime;
		float rotation = x * _rotation_speed * Time.deltaTime;

		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);
	}

	public void OnCallChangeFace()
	{
	}
}
