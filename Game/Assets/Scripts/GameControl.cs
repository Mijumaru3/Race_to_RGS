using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	//public variables
	public Light playerLight;
	public Light mainLight;
	public GameObject platform;

	public Text scoreText;
	public int score = 100000;

	public GameObject healthBar;
	public float maxHealth = 100f; //amount of health the player has
	public Image[] proj_Images; //array of the projectile images

	public PauseScript ps;

	//private variables
	float timer = 0.0f;
	public float currentHealth;

	//=============================================================================================================
	//Unity provided functions
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		platform.SetActive (false);
		UpdateText ();
		mainLight.intensity = 0;

		proj_Images[0].enabled = true;
		for(int i = 1; i < 4; i++)
		{
			proj_Images[i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 1.0f) {
			timer += Time.deltaTime;
		}
		else {
			score -= 1;
			UpdateText();
			timer = 0.0f;
		}
	}

	//============================================================================================================
	//custom functions
	void UpdateText()
	{
		scoreText.text = "Score: " + score;
	}

	public void turnOn()
	{
		playerLight.intensity = 0;
		playerLight.enabled = false;
		mainLight.intensity = 1;
		platform.SetActive (true);
	}

	public void Pause()
	{
		ps.paused = true;
	}

	//decreases the health of the player by however much damage is given as an argument to the function
	public void changeHealth(float damage)
	{
		currentHealth -= damage;
		healthBar.transform.localScale = new Vector3 (currentHealth / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	public void changeBullet(int length, int num)
	{
		for(int i = 0; i < length; i++)
		{
			if(i == num)
			{
				proj_Images[i].enabled = true;
			}
			else
			{
				proj_Images[i].enabled = false;
			}
		}
	}
}
