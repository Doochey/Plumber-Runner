using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
	public float percentSpeedIncrease = 0.1f;
	public float spawnRate = 1f;
	
	
	
	private int aSpawned;
	private float speed;
	private float oldDistance = 0;
	private float modifier;
	private GameObject gameController;
	private int bossCounter = 0;
	private int cooldownCounter = 0;
	
	void Start ()
	{
		gameController = GameObject.FindWithTag("GameController");
		aSpawned = 0;
		modifier = 1;
		InvokeRepeating("spawnRoid", 1f, spawnRate);
		
	}

	void Update()
	{
		int distanceValue = gameController.GetComponent<DistanceCounter>().GetDistance();
		if (distanceValue - oldDistance >= 500)
		{
			if (bossCounter >= 4)
			{
				CancelInvoke();
				spawnRate = 0.1f;
				modifier = 3;
				bossCounter = 0;
				cooldownCounter++;
				InvokeRepeating("spawnRoid", 0.1f, spawnRate);
				oldDistance = distanceValue;

			} else if (cooldownCounter >= 1)
			{
				CancelInvoke();
				modifier = 2;
				spawnRate = 0.7f;
				cooldownCounter = 0;
				InvokeRepeating("spawnRoid", 1f, spawnRate);
				oldDistance = distanceValue;
			}
			else
			{
				CancelInvoke();
				if (modifier < 5)
				{
					modifier += percentSpeedIncrease;
				}
				if (spawnRate >= 0.2)
				{
					spawnRate -= 0.1f;
				}
				oldDistance = distanceValue;
				bossCounter++;
				InvokeRepeating("spawnRoid", 1f, spawnRate);
				
			}
			
			

		}
	}

	void spawnRoid()
	{
		GameObject gameController = GameObject.FindWithTag("GameController");
		if (aSpawned < asteroidSpawnNumber)
		{
			// Generates Random X,Y,Z Coordinates around the origin of the spawner
			float x = Random.Range(xSpawnOrigin - randomSpawnRange, xSpawnOrigin + randomSpawnRange);
			float y = Random.Range(ySpawnOrigin - randomSpawnRange, ySpawnOrigin + randomSpawnRange);
			float z = Random.Range(zSpawnOrigin - randomSpawnRange, zSpawnOrigin + randomSpawnRange);
			
			
			
			
			Rigidbody asteroidClone = Instantiate(asteroidPrefabs[Random.Range(0,asteroidPrefabs.Length)], 
				(new Vector3(x, y, z)),transform.rotation);
			speed = Random.Range(minSpeed, maxSpeed) ;
			asteroidClone.velocity = transform.forward * -speed * modifier;
			aSpawned++;
		}
	}

	public void decreaseAspawned(int x)
	{
		aSpawned -= x;
	}

	
}
