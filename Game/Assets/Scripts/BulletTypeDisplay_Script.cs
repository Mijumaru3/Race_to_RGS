using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//display the current bullet type

public class BulletTypeDisplay_Script : MonoBehaviour {

	//projectile image variables
	public Image[] proj_Image;  //length should match the length of the projectiles array in the PlayerControl_Script
	int current_index;

	//===================================================================================================================================
	//Unity defined functions

	// Use this for initialization
	void Start () {
		//in the beginning the bullet type is the first bullet in the array
		proj_Image[0].enabled = true;
		current_index = 0;

		//disable all bullet images after the first one in the array
		for(int i = 1; i < proj_Image.Length; i++)
		{
			proj_Image[i].enabled = false;
		}
	}

	//====================================================================================================================================
	//Programmer defined functions

	//public functions

	//change the image of the currently active bullet
	public void ChangeBulletImage(int index)
	{
		//disable the old bullet image
		proj_Image[current_index].enabled = false;

		//enable the new bullet image and change the current index
		proj_Image[index].enabled = true;
		current_index = index;
	}
}
