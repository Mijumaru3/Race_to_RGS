using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	// VARIABLES
	public Transform _player_transform;

	[Range(0.01f, 1.0f)]
	public float _smooth_factor = 0.5f;

	public bool _look_at_player = false;

	private Vector3 _camera_offset;


	// FUNCTIONS

	// Use this for initialization
	void Start () {
		_camera_offset = transform.position - _player_transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 new_position = _player_transform.position + _camera_offset;

		transform.position = Vector3.Slerp (transform.position, new_position, _smooth_factor);

		if(_look_at_player)
		{
			transform.LookAt (_player_transform);
		}
	}
}
