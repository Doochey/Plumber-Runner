using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour
{
	public PowerupHandler powerupEffect;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			var exp = other.gameObject.GetComponent<ParticleSystem>();
			exp.Play();

			powerupEffect.Apply ();

			Destroy(gameObject);
		}
	}
}