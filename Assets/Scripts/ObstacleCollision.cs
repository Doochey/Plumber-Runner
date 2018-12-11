using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
	public int damageDealt;
    public GameObject collisionSound;

	private GameObject gameController;

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

			//attempt to inflict damage to player
			gameController.GetComponent<DamageHandler> ().takeDamage(damageDealt);

			//if player has no health left, destroy it
			if (gameController.GetComponent<DamageHandler>().getHealth () <= 0)
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