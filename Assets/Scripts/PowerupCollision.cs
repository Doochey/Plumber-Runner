using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour
{
	public PowerupHandler powerupEffect;
    public GameObject powerupSound;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (GameObject.FindWithTag("Player").GetComponent<Renderer>().enabled)
			{
				// Play powerup sound
				GameObject makeSound = Instantiate(powerupSound, this.transform.position, this.transform.rotation) as GameObject;

				//show visual effect
				var exp = other.gameObject.GetComponent<ParticleSystem>();
				exp.Play();

				//apply the powerup's effect
				powerupEffect.Apply ();

				// Decrease spawned Counter
				GameObject powerupSpawner = GameObject.FindWithTag("PSpawner");
				powerupSpawner.GetComponent<PowerupSpawner>().decreasePspawned(1);

				//destroy the powerup
				Destroy(gameObject);
			}
		}
	}
}