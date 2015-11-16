using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour {

	//public variables
	public GameObject controlMenuCanvas;
	public GameObject storyMenuCanvas;

	public string firstLevel;

	//private variables
	bool bringUpInfo = false;
	bool storyInfo = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			bringUpInfo = false;
		}

		if (bringUpInfo) {
			if(storyInfo)
			{
				controlMenuCanvas.SetActive(false);
				storyMenuCanvas.SetActive(true);
			}
			else {
				storyMenuCanvas.SetActive(false);
				controlMenuCanvas.SetActive(true);
			}
		}
		else {
			controlMenuCanvas.SetActive(false);
			storyMenuCanvas.SetActive(false);
			storyInfo = true;
		}
	}

	public void TurnOnInfo()
	{
		bringUpInfo = true;
	}

	public void StartGame()
	{
		Application.LoadLevel (firstLevel);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void NextPage()
	{
		storyInfo = false;
	}

	public void PrevPage()
	{
		storyInfo = true;
	}

}
