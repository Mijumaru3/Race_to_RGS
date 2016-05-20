using UnityEngine;
using System.Collections;

//handle the lights and the stuff associated with the lights being on or off

public class Switch_Script : MonoBehaviour {

	//variables that deal with the light
	public Light playerLight;
	public Light mainLight;
	public Light switchLight;

	//variables that deal with the cameras
	public Camera levelCam;
	public Camera playerCam;
	float initialCamTimer = 0.0f;
	float switchCamTimer = 0.0f;
	bool levelStart = true;

	//variables that deal with the doors
	public GameObject closedDoors;
	public GameObject openDoors;

	//variables that deal with the invisible platforms
	public GameObject platform;

	//===============================================================================================================================
	//Unity defined functions

	// Use this for initialization
	void Start () {

		//deactivate all the objects that are active when the light is on
		platform.SetActive(false);
		openDoors.SetActive(false);
		playerCam.enabled = false;
		mainLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		//at the start of the level show the player the whole level for a short period of time
		if(levelStart)
		{
			if(initialCamTimer < 6.0f)
			{
				//increment the timer
				initialCamTimer += Time.deltaTime;
			}
			else
			{
				//once the time has been reached, switch to the player's camera instead of the level's camera
				playerCam.enabled = true;
				levelCam.enabled = false;
				levelStart = false;
			}
		}
		else
		{
			//switch to the level cam for a brief amout of time when the lights are turned on so that 
			//the player can see the doors opening and the way to them
			if(levelCam.enabled && switchCamTimer < 5.0f)
			{
				//increment the timer
				switchCamTimer += Time.deltaTime;
			}
			else if(levelCam.enabled && switchCamTimer >= 5.0f)
			{
				//switch back to the player's camera after a bit
				playerCam.enabled = true;
				levelCam.enabled = false;
			}
		}
	}

	//=================================================================================================================================
	//Programmer defined functions

	//public functions

	//turn on the lights and make invisible platforms visisble
	//also open the doors and show the player the whole level for a bit
	public void TurnOn()
	{
		//turn off the personal object lights because we don't need them anymore
		switchLight.enabled = false;
		playerLight.enabled = false;

		//turn on the main light
		mainLight.intensity = 1;

		//make platform appear
		platform.SetActive(true);

		//open the doors
		closedDoors.SetActive(false);
		openDoors.SetActive(true);

		//show the whole level
		playerCam.enabled = false;
		levelCam.enabled = true;
		switchCamTimer = 0.0f;
	}
}
