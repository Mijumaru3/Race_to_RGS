using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Script : MonoBehaviour {

	//public variables
	public string startScreen;
	public bool paused = false;
	public GameObject pauseMenu_canvas;
	public GameObject cInfo;
	public GameObject cInfo_background;

	//private variables
	bool showControls = false;

	//=================================================================================================================================
	//Unity defined funcions
	
	// Update is called once per frame
	void Update () 
	{
		//if paused is true then pause the game and show the menu
		if (paused) 
		{
			pauseMenu_canvas.SetActive (true);
			Time.timeScale = 0f;
		}
		else 
		{
			//if paused is false then deactivate the menu canvas and let time start again
			cInfo.SetActive(false);
			cInfo_background.SetActive(false);
			pauseMenu_canvas.SetActive(false);
			Time.timeScale = 1f;
		}

		//if the escape key is pressed then set paused variable
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		//show show the control info box
		if (showControls) {
			cInfo.SetActive(true);
			cInfo_background.SetActive(true);
		}
		else
		{
			//don't show the control info box
			cInfo.SetActive(false);
			cInfo_background.SetActive(false);
		}
	}

	//==========================================================================================================================
	//Programmer defined functions

	//set paused to false so that Unity knows to set time to move again
	public void ResumeLevel()
	{
		paused = false;
	}

	//quit the game
	public void Quit()
	{
		Application.Quit ();
	}

	//go to the start screen
	public void ToStart()
	{
		SceneManager.LoadScene(startScreen);
	}

	//set showControls variable
	public void ControlInfo()
	{
		showControls = !showControls;
	}
}
