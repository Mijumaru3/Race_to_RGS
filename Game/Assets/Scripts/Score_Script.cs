using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//display the score

public class Score_Script : MonoBehaviour {

	//score variables
	public Text scoreText;
	public int score = 100000;
	float timer;

	//===================================================================================================================
	//Unity defined functions

	// Use this for initialization
	void Start () {
		//show the score
		UpdateText();
	}

	void Update()
	{
		//decrease the score every couple of seconds as the time goes on until the score is zero
		if (timer < 1.0f) {
			timer += Time.deltaTime;
		}
		else {
			score -= 1;
			UpdateText();
			timer = 0.0f;
		}
	}
	
	//=====================================================================================================================
	//Programmer defined functions

	//public functions

	//change the score and update the score text
	public void ChangeScore(int value)
	{
		score += value;
		UpdateText();
	}

	//------------------------------------------------------------------------------------------------------------------
	//private functions

	//update the text component of the score text
	void UpdateText()
	{
		scoreText.text = "Score: " + score;
	}
}
