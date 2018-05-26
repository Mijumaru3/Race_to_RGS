using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//controls the title screen

public class TitleScreen_Script : MonoBehaviour {

	//variables that deal with the menu that describes controls
	public GameObject controlMenuCanvas;
	bool bringUpInfo = false;

	//variables that deal with the menu that tells the story
	public GameObject storyMenuCanvas;
	bool storyInfo = true;

	//variables that deal with the menu that describes the bullets
	public GameObject bulletInfoCanvas;
	bool bulletInfo = false;

	//variable that stores the name of the first level of the game
	public string firstLevel;

	//==========================================================================================================================================
	//Unity defined functions

	// Update is called once per frame
	void Update ()
	{
		//if the player hits the escape key then set the variable that says to show the info menu to false
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			bringUpInfo = false;
		}
	

		//if bringnig up the info menu is true
		if (bringUpInfo) 
		{
			//if showing the story info then the story info canvas is active and the control canvas is deactivated
			if(storyInfo)
			{
				controlMenuCanvas.SetActive(false);
				storyMenuCanvas.SetActive(true);
			}
			else 
			{
				//if the story canvas is not being shown then show the control menu
				storyMenuCanvas.SetActive(false);
				controlMenuCanvas.SetActive(true);

				//if showing the control menu then see if should also show the bullet information
				if(bulletInfo)
				{
					bulletInfoCanvas.SetActive(true);
				}
				else
				{
					bulletInfoCanvas.SetActive(false);
				}
			}
		}
		else
		{
			//if not show the info then deactivate all info canvases and set storyInfo to true so that it will start at the 
			//first page of the info canvases when showing them again
			controlMenuCanvas.SetActive(false);
			bulletInfoCanvas.SetActive(false);
			storyMenuCanvas.SetActive(false);
			storyInfo = true;
		}
	}

	//============================================================================================================================
	//Programmer defined functions

	//public functions

	//set the variable that says to bring up the info menu to true
	public void TurnOnInfo()
	{
		bringUpInfo = true;
	}

	//load the first level of the game
	public void StartGame()
	{
		SceneManager.LoadScene(firstLevel);
	}

	//quit the game
	public void QuitGame()
	{
		Application.Quit ();
	}

	//FIXME: make the bullet info a page in the info menu also so that you can just use NextPage and PrevPage to go through the infomration

	//go to the next page of the info menu
	public void NextPage()
	{
		storyInfo = false;
	}

	//go to the previous page of the info menu
	public void PrevPage()
	{
		storyInfo = true;
	}

	//show the inforomation for the bullet
	public void ShowBulletInfo()
	{
		bulletInfo = !bulletInfo;
	}

}
