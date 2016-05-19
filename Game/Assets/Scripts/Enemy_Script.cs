using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {

	public float speed = -9f;
	public int type;
	public float damage = 5f;
	public bool moveRight = true;

	public Transform wallLeft;
	public float wallCheckRadius;
	public LayerMask wallMask;

	//variables that deal with the game controller object
	GameObject controller;
	Score_Script s_s;
	GameControl_Script gc_s;

	Rigidbody2D rb;
	bool hitWall = false;

	// Use this for initialization
	void Start () {
		//get the scripts of the game controller object
		controller = GameObject.Find("GameController");
		s_s = controller.GetComponent<Score_Script>();
		gc_s = controller.GetComponent<GameControl_Script>();

		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		hitWall = Physics2D.OverlapCircle(wallLeft.position, wallCheckRadius, wallMask);

		if(hitWall)
		{
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
			speed = -speed;
		}

		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "bullet")
		{
			int bulletType = col.gameObject.GetComponent<Bullet_Script>().Type();
			Destroy(col.gameObject);
			//rubber and ice enemeies can be destroyed with quicksand bullets
			if((type == 0 && bulletType == 2) || (type == 1 && bulletType == 2))
			{
				s_s.ChangeScore(5);
				Destroy(gameObject);
			}
			else if(type == 4 && bulletType == 3)
			{
				s_s.ChangeScore(5);
				Destroy(gameObject);
			}
		}

		if(col.gameObject.tag == "Player")
		{
			var playerScript = col.gameObject.GetComponent<PlayerControl_Script>();
			playerScript.knockbackCount = playerScript.knockbackTime;

			if(col.transform.position.x < transform.position.x) 
			{
				playerScript.knockbackFromRight = true;
			}
			else
			{
				playerScript.knockbackFromRight = false;
			}

			gc_s.ChangeHealth(damage);
		}
	}
}
