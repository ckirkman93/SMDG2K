using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour 
{
	public GameObject enemyPrefab;
	private float COOL_DOWN = 1f;
	private float coolDown;
	private Enemy enemyScript;
	// Use this for initialization
	void Start () 
	{
		coolDown = COOL_DOWN;
		//TODO: Replace this later
		/*
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 7+y; x++)
			{
				Vector3 pos = new Vector3((x-3.0f-0.5f*y)*0.5f, (y+6.0f)*0.5f, 0);
				GameObject enemy = (GameObject) Instantiate(enemyPrefab, pos, Quaternion.identity);
				enemy.transform.parent = transform;
				enemyScript = (Enemy) enemy.GetComponent("Enemy");
			}
		}
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		//This makes sure asteroids don't spawn all the time.
		if (coolDown > 0) 
		{
			coolDown -= Time.deltaTime;
		}

		//This spawns asteroids and makes them fly toward the center
		//TODO: Make them disappear when they strike earth.
		//TODO: Separate asteroids and enemies so that inheritance is easier later
		if (coolDown <= 0) {
			coolDown = COOL_DOWN;
			int y = Random.Range(0, 3);
			int x = Random.Range(0, 7+y);
			Vector3 pos = new Vector3((x-3.0f-0.5f*y)*0.5f, (y+6.0f)*0.5f, 0);
			GameObject enemy = (GameObject) Instantiate(enemyPrefab, pos, Quaternion.identity);
			enemy.transform.parent = transform;
			enemyScript = (Enemy) enemy.GetComponent("Enemy");
			enemyScript.setVelocity(new Vector2(-1*enemy.transform.position.x, -1*enemy.transform.position.y));
		}
	}
}
