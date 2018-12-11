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

				var exp = other.gameObject.GetComponent<ParticleSystem>();
				exp.Play();

				powerupEffect.Apply ();

				Destroy(gameObject);
			}
            
		}
	}
}