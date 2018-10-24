using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierIncreaseHandler : PowerupHandler
{
	public int increaseAmount;

	private MultiplierCounter multiplierCount;

	void Start()
	{
		GameObject multiplierCountObject = GameObject.FindWithTag("Multiplier");
		multiplierCount = multiplierCountObject.GetComponent<MultiplierCounter> ();
	}

	public override void Apply()
	{
		multiplierCount.increaseMultiplier (increaseAmount);
	}
}