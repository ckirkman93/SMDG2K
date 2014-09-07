using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour 
{
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () 
	{
		// Create a grid of enemies
		for (int y = 0; y < 3; y++)
		{
			for (int x = 0; x < 7+y; x++)
			{
				Vector3 pos = new Vector3((x-3.0f-0.5f*y)*0.5f, (y+6.0f)*0.5f, 0);
				GameObject enemy = (GameObject) Instantiate(enemyPrefab, pos, Quaternion.identity);
				enemy.transform.parent = transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
