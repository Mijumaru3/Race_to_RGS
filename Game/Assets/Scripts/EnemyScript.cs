using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = -9f;
	public int type;
	public float damage = 5f;
	public bool moveRight = true;

	public Transform wallLeft;
	public float wallCheckRadius;
	public LayerMask wallMask;

	GameControl controller;
	Rigidbody2D rb;
	bool hitWall = false;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find("GameController").GetComponent<GameControl>(); 
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
			int bulletType = col.gameObject.GetComponent<BulletScript>().Type();
			Destroy(col.gameObject);
			if((type == 0 && bulletType == 2) || (type == 1 && bulletType == 2))
			{
				controller.incrementScore(5);
				Destroy(gameObject);
			}
			else if(type == 4 && bulletType == 3)
			{
				controller.incrementScore(5);
				Destroy(gameObject);
			}
		}

		if(col.gameObject.tag == "Player")
		{
			var playerScript = col.gameObject.GetComponent<PlayerControl>();
			playerScript.knockbackCount = playerScript.knockbackTime;

			if(col.transform.position.x < transform.position.x) 
			{
				playerScript.knockbackFromRight = true;
			}
			else
			{
				playerScript.knockbackFromRight = false;
			}

			controller.changeHealth(damage);
		}
	}
}
