using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement script for the player

public class WalkController : MonoBehaviour {

	// MOVEMENT VARIABLES
	public float velocity_ = 6f;
	public float max_velocity_ = 10f;
	public float time_to_zero_max_ = 2.5f;
	private float acceleration_;
	private Rigidbody rb_;

	// ROTATION SPEED VARIABLE(S)
	public float rotation_speed_ = 100f;

	// ==============================================================================
	// UNITY FUNCTIONS

	void Awake ()
	{
		rb_ = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start ()
	{
		acceleration_ = max_velocity_ / time_to_zero_max_;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// MOVEMENT
		velocity_ += acceleration_ * Time.deltaTime;
		velocity_ = Mathf.Min (velocity_, max_velocity_);
		/*
		float translation = Input.GetAxis("Vertical") * velocity_;
		float rotation = Input.GetAxis("Horizontal") * rotation_speed_;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		*/
	}

	void FixedUpdate()
	{
		rb_.velocity = transform.forward * velocity_;
	}

	// ==============================================================================
	// CUSTOM FUNCTIONS
}
