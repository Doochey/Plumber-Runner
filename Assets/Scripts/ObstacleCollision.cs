using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
	public int damageDealt;

	void OnTriggerEnter(Collider other)
	{
		if ( other.gameObject.CompareTag("Player"))
		{
			//play particle explosion
			var exp = other.gameObject.GetComponent<ParticleSystem>();
			exp.Play();

			//inflict damage to player
			other.gameObject.GetComponent<ShipHealth> ().takeDamage (damageDealt);

			//if player has no health left, destroy it
			if (other.gameObject.GetComponent<ShipHealth>().getHealth () <= 0)
			{
				Destroy(other.gameObject, exp.main.duration);
				//other.gameObject.SetActive(false);
			}
			//otherwise destroy obstacle
			else
			{
				Destroy (this.gameObject);
			}
		}

	}
}