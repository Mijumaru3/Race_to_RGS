using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	//public variables
	public Light playerLight;
	public Light mainLight;
	public GameObject platform;
	public int score = 100000;

	public PauseScript ps;

	//private variables
	float timer = 0.0f;

	//=============================================================================================================
	//Unity provided functions
	// Use this for initialization
	void Start () {
		platform.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L))
			turnOn ();

		if (timer < 5.0f) {
			timer += Time.deltaTime;
		}
		else {
			score -= 1;
			timer = 0.0f;
		}
	}

	//============================================================================================================
	//custom functions
	public void turnOn()
	{
		playerLight.enabled = false;
		mainLight.intensity = 1;
		platform.SetActive (true);
	}

	public void Pause()
	{
		ps.paused = true;
	}
}
