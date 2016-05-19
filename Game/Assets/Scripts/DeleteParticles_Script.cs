﻿using UnityEngine;
using System.Collections;

public class DeleteParticles_Script: MonoBehaviour {

	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ps.isPlaying == false)
		{
			Destroy(gameObject);
		}
	}
}
