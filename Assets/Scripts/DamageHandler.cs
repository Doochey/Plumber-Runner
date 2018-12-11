using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for invincibility, from powerups and taking damage
public class DamageHandler : MonoBehaviour
{
	public GameObject player;
	public int gracePeriod;
	public int startingHealth;

	private int healthCount;
	private bool invincible;
	private IEnumerator invincibilityInst;

	void Start ()
	{
		invincible = false;
		healthCount = startingHealth;
	}

	//apply damage and grace period, only if not currently invincible
	public void takeDamage(int damage)
	{
		if (!invincible)
		{
			healthCount -= damage;
			invincibilityInst = Invincibility (gracePeriod);
			StartCoroutine (invincibilityInst);
		}
	}

	//heal by amount healAmount, up to max of startingHealth
	public void heal(int healAmount)
	{
		if (healthCount + healAmount >= startingHealth)
		{
			healthCount = startingHealth;
		}
		else
		{
			healthCount += healAmount;
		}
	}

	//apply invincibility, refreshing coroutine if necessary
	public void TurnInvincible(int invincibilityTime)
	{
		if (invincible)
		{
			StopCoroutine (invincibilityInst);
		}
		invincibilityInst = Invincibility (invincibilityTime);
		StartCoroutine (invincibilityInst);
	}

	//coroutine to keep invincible true for a set amount of seconds
	IEnumerator Invincibility(int invincibilityTime)
	{
		invincible = true;
		player.GetComponent<Light>().enabled = true;
		yield return new WaitForSeconds (invincibilityTime);
		player.GetComponent<Light> ().enabled = false;
		invincible = false;
	}

	public bool isInvincible()
	{
		return invincible;
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
