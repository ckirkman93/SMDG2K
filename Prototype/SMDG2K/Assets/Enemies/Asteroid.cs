using UnityEngine;
using System.Collections;

public class Asteroid : Enemy {

	void OnCollisionEnter2D(Collision2D coll)
	{
		// If Ball collides with enemy, enemy loses health
		if(coll.gameObject.tag == "Ball")
		{
			health -= 10;
		}

		if(coll.gameObject.tag == "Planet")
		{
			health -= health;
		}
	}
}
