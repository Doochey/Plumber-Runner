using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
	public int startingHealth;

	private int healthCount;

	void Start ()
	{
		healthCount = startingHealth + GameObject.FindWithTag("GameController").GetComponent<UpgradeHandler>().getValues()[0];
	}

	public void takeDamage(int damage)
	{
		healthCount -= damage;
		if (healthCount == 0)
		{
			GameObject.FindWithTag("Fill").SetActive(false);
		}
	}

	public int getHealth()
	{
		return healthCount;
	}

	public int getMaxHealth()
	{
		return startingHealth + GameObject.FindWithTag("GameController").GetComponent<UpgradeHandler>().getValues()[0];
	}
}
