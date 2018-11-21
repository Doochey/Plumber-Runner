using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPointsHandler : PowerupHandler
{
	public int bonusAmount;

	private ScoreCounter scoreCount;

	void Start()
	{
		GameObject scoreCountObject = GameObject.FindWithTag("GameController");
		scoreCount = scoreCountObject.GetComponent<ScoreCounter> ();
	}

	public override void Apply()
	{
		scoreCount.Bonus (bonusAmount);
	}
}