using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public float health;
	public Vector2 velocity;
	public Transform self;

	// Use this for initialization
	void Start () 
	{
		//velocity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		velocity.Normalize();
		velocity *= 2f;
		self.Translate( velocity * Time.deltaTime);
	}

	void FixedUpdate()
	{
		// If health of enemy falls below 0, destory it
		if (health <= 0)
		{
			Destroy(gameObject);
			print ("Enemy Destroyed");
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// If Ball collides with enemy, enemy loses health
		if(coll.gameObject.tag == "Ball")
		{
			health -= 10;
		}
	}

	public void setVelocity (Vector2 vector) {
		velocity = vector;
	}
}
