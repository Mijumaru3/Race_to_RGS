using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen_Script : MonoBehaviour {

	//public variables
	public GameObject controlMenuCanvas;
	public GameObject storyMenuCanvas;
	public GameObject bulletInfoCanvas;

	public string firstLevel;

	//private variables
	bool bringUpInfo = false;
	bool storyInfo = true;
	bool bulletInfo = false;

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
		else {
			controlMenuCanvas.SetActive(false);
			bulletInfoCanvas.SetActive(false);
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
		//Application.LoadLevel (firstLevel);
		SceneManager.LoadScene(firstLevel);
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

	public void ShowBulletInfo()
	{
		bulletInfo = !bulletInfo;
	}

}
