using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
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
}
