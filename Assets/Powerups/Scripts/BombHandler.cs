using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : PowerupHandler
{
	public float explosionRadius;

	private GameObject player;

	void Start ()
	{
		player = GameObject.FindWithTag ("Player");
	}

	public override void Apply()
	{
		Collider[] nearbyObjects = Physics.OverlapSphere (player.transform.position, explosionRadius);

		var exp = player.GetComponent<ParticleSystem>();
		exp.Play();

		foreach (Collider neighbour in nearbyObjects)
		{
			if ((neighbour.tag == "Asteroid") || (neighbour.tag == "Enemy"))
			{
				Destroy (neighbour.gameObject);
			}
		}
	}
}
