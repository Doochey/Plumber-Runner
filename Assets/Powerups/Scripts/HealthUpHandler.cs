using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpHandler : PowerupHandler
{
	public int healAmount;

	private DamageHandler damageHandler;

	void Start ()
	{
		GameObject gameController = GameObject.FindWithTag("GameController");
		damageHandler = gameController.GetComponent<DamageHandler> ();
	}

	public override void Apply()
	{
		damageHandler.GetComponent<DamageHandler> ().heal (healAmount);
	}
}
