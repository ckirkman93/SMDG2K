using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public float health;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}	

	void FixedUpdate ()
	{
		// If health is below or equal to 0, ball is destroyed
		if (health <= 0)
		{
			Destroy(gameObject);
			print ("Ball Destroyed");
		}
	}

	// Launch ball with an initial velocity
	public void Launch(float movementSpeed)
	{
		transform.parent = null;
		rigidbody2D.velocity = transform.TransformDirection(Vector2.one) * movementSpeed;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		// If Ball collides with planet, the ball is destroyed
		if(coll.gameObject.tag == "Planet")
		{
			Destroy(gameObject);
		}

	}

	void OnCollisionExit2D(Collision2D coll)
	{
		// If Ball collides with enemy, on exit, it will lose health
		if(coll.gameObject.tag == "Enemy")
		{
			health -= 10;
		}
	}

}
