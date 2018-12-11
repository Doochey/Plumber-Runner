using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateHandler : PowerupHandler
{
	public int fireRateMultiplier;
	public int fireRateTime;

	private ShootLaserScript laserScript;
	private ShootPlasmaScript plasmaScript;

	void Start ()
	{
		GameObject player = GameObject.FindWithTag("Player");
		laserScript = player.GetComponent<ShootLaserScript> ();
		plasmaScript = player.GetComponent<ShootPlasmaScript> ();
	}

	public override void Apply()
	{
		plasmaScript.fireRateUp (fireRateMultiplier, fireRateTime);
		laserScript.fireRateUp (fireRateMultiplier, fireRateTime);
	}
}
