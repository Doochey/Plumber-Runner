using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	
	public float enemySpawnNumber = 1f;
	public float minSpeed = 10f;
	public float maxSpeed = 50f;
	public float randomSpawnRange = 10f;
	public float ySpawnOrigin = 1f;
	public float xSpawnOrigin = 0f;
	public float zSpawnOrigin = 138f;
	public Rigidbody[] spacehipPrefabs;
	
	
	
	private int eSpawned;
	private float speed;

	
	
	// Update is called once per frame
	void Start ()
	{
		eSpawned = 0;
		InvokeRepeating("spawnEnemy", 1f, 5f);
		
	}

	void spawnEnemy()
	{
		if (eSpawned < enemySpawnNumber)
		{
			// Generates Random X,Y,Z Coordinates around the origin of the spawner
			float x = Random.Range(xSpawnOrigin - randomSpawnRange, xSpawnOrigin + randomSpawnRange);
			float y = Random.Range(ySpawnOrigin - randomSpawnRange, ySpawnOrigin + randomSpawnRange);
			float z = Random.Range(zSpawnOrigin - randomSpawnRange, zSpawnOrigin + randomSpawnRange);
			
			
			
			
			Rigidbody enemyClone = Instantiate(spacehipPrefabs[Random.Range(0,spacehipPrefabs.Length)], 
				(new Vector3(x, y, z)),transform.rotation);
			speed = Random.Range(minSpeed, maxSpeed);
			enemyClone.velocity = transform.up * speed;
			eSpawned++;
		}
	}

	
}
