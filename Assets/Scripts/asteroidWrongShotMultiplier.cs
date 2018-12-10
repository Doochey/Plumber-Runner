using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidWrongShotMultiplier : MonoBehaviour
{
	public Rigidbody[] asteroids;
	public float speed = 1f;
	public float scale = 0.8f;


	void OnTriggerEnter(Collider other)
	{
		// If the plasma beam hits an asteroid:
		if (other.gameObject.CompareTag("Plasma"))
		{
			GameObject player = GameObject.FindWithTag("Player");
			Vector3 pos = transform.position;
			Vector3 deltaScale = new Vector3(scale, scale, scale);
			
			// Make three smaller asteroids spawn
			// Asteroid a always moves towards the player
			Rigidbody a = Instantiate(asteroids[Random.Range(0,asteroids.Length)], (pos),Quaternion.identity);
			a.transform.localScale -= deltaScale;
			a.transform.LookAt(player.transform);
			a.velocity = (player.transform.position- a.transform.position)* speed;
			Destroy(a,10f);
			
			Rigidbody b = Instantiate(asteroids[Random.Range(0,asteroids.Length)], (pos),transform.rotation);
			b.transform.localScale -= deltaScale;
			b.velocity = transform.forward * speed;
			Destroy(b,10f);
			Rigidbody c = Instantiate(asteroids[Random.Range(0,asteroids.Length)], (pos),transform.rotation);
			c.transform.localScale -= deltaScale;
			c.velocity = transform.up* speed;
			Destroy(c,10f);
			
			
			Destroy(gameObject);
		}
	}
}
