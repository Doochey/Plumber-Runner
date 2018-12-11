using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {

	public float powerupSpawnNumber = 1f;
	public float minSpeed = 10f;
	public float maxSpeed = 50f;
	public float randomSpawnRange = 10f;
	public float ySpawnOrigin = 1f;
	public float xSpawnOrigin = 0f;
	public float zSpawnOrigin = 138f;
	public Rigidbody[] powerupPrefabs;
	public float spawnInterval = 6;

	private int pSpawned;
	private float speed;

	void Start ()
	{
		pSpawned = 0;
		InvokeRepeating("spawnPowerup", 5f, spawnInterval);
	}

	void spawnPowerup()
	{
		if (pSpawned < powerupSpawnNumber)
		{
			// Generates Random X,Y,Z Coordinates around the origin of the spawner
			float x = Random.Range(xSpawnOrigin - randomSpawnRange, xSpawnOrigin + randomSpawnRange);
			float y = Random.Range(ySpawnOrigin - randomSpawnRange, ySpawnOrigin + randomSpawnRange);
			float z = Random.Range(zSpawnOrigin - randomSpawnRange, zSpawnOrigin + randomSpawnRange);

			Rigidbody powerupClone = Instantiate(powerupPrefabs[Random.Range(0,powerupPrefabs.Length)], 
				(new Vector3(x, y, z)),transform.rotation * Quaternion.Euler (new Vector3(0,180,0)));
			speed = Random.Range(minSpeed, maxSpeed);
			powerupClone.velocity = transform.up * speed;
			pSpawned++;
		}
	}

	public void decreasePspawned(int x)
	{
		pSpawned -= x;
	}
}
