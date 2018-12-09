﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
	public int damageDealt;
    public GameObject collisionSound;
	public GameObject gameController;

	private void Start()
	{
		gameController = GameObject.FindWithTag ("GameController");
	}

    void OnTriggerEnter(Collider other)
	{
        if ( other.gameObject.CompareTag("Player"))
		{
			GameObject player = other.gameObject;

            // Play the explosion sound
            GameObject makeSound = Instantiate(collisionSound, this.transform.position, this.transform.rotation) as GameObject;

            //play particle explosion
            var exp = player.GetComponent<ParticleSystem>();
			exp.Play();

			//inflict damage to player if they're not invincible, and start grace period
			if (!gameController.GetComponent<DamageHandler>().isInvincible ())
			{
				player.GetComponent<ShipHealth>().takeDamage (damageDealt);
				gameController.GetComponent<DamageHandler> ().damageTaken();
			}

			//if player has no health left, destroy it
			if (player.GetComponent<ShipHealth>().getHealth () <= 0)
			{
				// Disables player movement
				player.GetComponent<Movement>().enabled = false;
				
			
				// Disables mesh renderer of player object making them invisible
				Renderer rend = player.GetComponent<Renderer>();
				rend.enabled = false;
			
				// Disables all children of the player object
				foreach (Transform child in player.transform)
				{
					child.gameObject.SetActive(false);
				}
				
				Destroy(player, exp.main.duration);
			}
			//otherwise destroy obstacle
			else
			{
				Destroy (this.gameObject);
			}
		}

	}
}