using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//deal with the odds-and ends that the other scripts on the game controller don't handle
/* handles:
 * -respawing
 * -health & healthbar
 * -pausing
 * -end game
*/

public class GameControl_Script : MonoBehaviour {

	//variables that deal with respawning
	public GameObject startPoint;
	public GameObject deathParticles;
	public float respawnDelay = 1f;

	//variables that deal with the healthbar
	public GameObject healthBar;
	public float maxHealth = 100f;
	float currentHealth;

	//variables that deal with pausing the game
	public Pause_Script ps;

	//variables that deal with the end of the game
	public GameObject endCanvas;

	bool lose = false;
	public Text lostText;
	public Image loseImage;

	bool win = false;
	public Text winText;
	public Image winImage;

	//variables that deal with the player object
	PlayerControl_Script player;

	//==============================================================================================================================
	//Unity defined functions

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<PlayerControl_Script>();
		currentHealth = maxHealth;
		endCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		//if health drops to zero (or less) then player has lost the game
		if(currentHealth <= 0)
		{
			lose = true;
		}

		if(win)
		{
			//if the player has won then stop the time and enable the ending canvas with
			//the winning text and image
			Time.timeScale = 0f;
			endCanvas.SetActive(true);
			lostText.enabled = false;
			loseImage.enabled = false;
			winText.enabled = true;
			winImage.enabled = true;
		}
		else if(lose)
		{
			//if the player has lost then stop the time and enbale the ending canvas with
			//the losing text and image
			Time.timeScale = 0f;
			endCanvas.SetActive(true);
			lostText.enabled = true;
			loseImage.enabled = true;
			winText.enabled = false;
			winImage.enabled = false;
		}
	}

	//====================================================================================================================================
	//Programmer defined functions

	//public functions

	//pause the game
	public void Pause()
	{
		ps.paused = true;
	}

	//decreases the health of the player by however much damage is given as an argument to the function
	public void ChangeHealth(float damage)
	{
		currentHealth -= damage;
		healthBar.transform.localScale = new Vector3 (currentHealth / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	//when the doors have been reached then you've won
	public void ReachDoors()
	{
		win = true;
	}

	//start the respawn coroutine
	public void Respawn()
	{
		StartCoroutine("Respawn_Coroutine");
	}

	//respawn the player at the start
	public IEnumerator Respawn_Coroutine()
	{
		//play the death particles and "kill" the player by disabling player object
		Instantiate(deathParticles, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;

		//wait a bit
		yield return new WaitForSeconds(respawnDelay);

		//start the player at the beginning again and enable player object
		player.transform.position = startPoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
	}
}
