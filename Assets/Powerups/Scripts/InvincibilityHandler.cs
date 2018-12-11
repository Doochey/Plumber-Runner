using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityHandler : PowerupHandler
{
	public int invincibilityTime;

	private DamageHandler damageHandler;

	void Start ()
	{
		GameObject gameController = GameObject.FindWithTag("GameController");
		damageHandler = gameController.GetComponent<DamageHandler> ();
	}

	public override void Apply()
	{
		damageHandler.TurnInvincible (invincibilityTime);
	}
}
