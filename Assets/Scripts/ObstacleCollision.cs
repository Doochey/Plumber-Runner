﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
	public int damageDealt;
    public GameObject collisionSound;

    void OnTriggerEnter(Collider other)
	{
        if ( other.gameObject.CompareTag("Player") && GameObject.FindWithTag("Player").GetComponent<Renderer>().enabled)
		{
            // Play the explosion sound
            GameObject makeSound = Instantiate(collisionSound, this.transform.position, this.transform.rotation) as GameObject;

            //play particle explosion
            var exp = other.gameObject.GetComponent<ParticleSystem>();
			exp.Play();

			//inflict damage to player
			other.gameObject.GetComponent<ShipHealth> ().takeDamage (damageDealt);

			//if player has no health left, destroy it
			if (other.gameObject.GetComponent<ShipHealth>().getHealth () <= 0)
			{
				// Disables player movement
				other.gameObject.GetComponent<Movement>().enabled = false;
				
			
				// Disables mesh renderer of player object making them invisible
				Renderer rend = other.gameObject.GetComponent<Renderer>();
				rend.enabled = false;
			
				// Disables all children of the player object
				foreach (Transform child in other.gameObject.transform)
				{
					child.gameObject.SetActive(false);
				}
				
				
				Destroy(other.gameObject, exp.main.duration);
			}
			//otherwise destroy obstacle
			else
			{
				if (gameObject.tag.Equals("Asteroid"))
				{
					// Decrease aSpawned Counter
					GameObject asteroidSpawner = GameObject.FindWithTag("ASpawner");
					asteroidSpawner.GetComponent<AsteroidSpawner>().decreaseAspawned(1);
				} else if (gameObject.tag.Equals("Enemy"))
				{
					// Decrease eSpawned Counter
					GameObject enemySpawner = GameObject.FindWithTag("ESpawner");
					enemySpawner.GetComponent<EnemySpawner>().decreaseEspawned(1);
				}
				Destroy (this.gameObject);
			}
		}

	}

}