using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	
	public float asteroidSpawnNumber = 1f;
	public float minSpeed = 10f;
	public float maxSpeed = 50f;
	public float randomSpawnRange = 10f;
	public float ySpawnOrigin = 1f;
	public float xSpawnOrigin = 0f;
	public float zSpawnOrigin = 138f;
	public Rigidbody[] asteroidPrefabs;
	
	
	
	private int aSpawned;
	private float speed;

	
	void Start ()
	{
		aSpawned = 0;
		InvokeRepeating("spawnRoid", 1f, 2f);
		
	}

	void spawnRoid()
	{
		if (aSpawned < asteroidSpawnNumber)
		{
			// Generates Random X,Y,Z Coordinates around the origin of the spawner
			float x = Random.Range(xSpawnOrigin - randomSpawnRange, xSpawnOrigin + randomSpawnRange);
			float y = Random.Range(ySpawnOrigin - randomSpawnRange, ySpawnOrigin + randomSpawnRange);
			float z = Random.Range(zSpawnOrigin - randomSpawnRange, zSpawnOrigin + randomSpawnRange);
			
			
			
			
			Rigidbody asteroidClone = Instantiate(asteroidPrefabs[Random.Range(0,asteroidPrefabs.Length)], 
				(new Vector3(x, y, z)),transform.rotation);
			speed = Random.Range(minSpeed, maxSpeed);
			asteroidClone.velocity = transform.forward * -speed;
			aSpawned++;
		}
	}

	public void decreaseAspawned(int x)
	{
		aSpawned -= x;
	}

	
}
