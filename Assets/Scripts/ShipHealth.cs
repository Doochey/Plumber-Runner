using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
	public int startingHealth;
	public GameObject healthBar;

	private int healthCount;

	void Start ()
	{
		healthCount = startingHealth;
		healthBar.GetComponent<HealthCounter> ().updateHealth ();
	}

	void Update ()
	{
		
	}

	public void takeDamage(int damage)
	{
		healthCount -= damage;
		healthBar.GetComponent<HealthCounter> ().updateHealth ();
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
