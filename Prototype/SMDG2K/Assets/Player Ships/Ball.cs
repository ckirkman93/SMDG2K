using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{

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

}
