using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
	public int startingHealth;

	private int healthCount;

	void Start ()
	{
		healthCount = startingHealth;
	}

	public void takeDamage(int damage)
	{
		healthCount -= damage;
	}

	public int getHealth()
	{
		return healthCount;
	}

	public int getMaxHealth()
	{
		return startingHealth;
	}
}
