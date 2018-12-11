using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateHandler : PowerupHandler
{
	public int fireRateMultiplier;
	public int fireRateTime;

	private ShootScript shootScript;

	void Start ()
	{
		GameObject player = GameObject.FindWithTag("Player");
		shootScript = player.GetComponent<ShootScript> ();
	}

	public override void Apply()
	{
		shootScript.FireRateUp (fireRateMultiplier, fireRateTime);
	}
}
