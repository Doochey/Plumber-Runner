using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for invincibility, from powerups and taking damage
public class DamageHandler : MonoBehaviour
{
	public GameObject player;
	public int gracePeriod;

	private bool invincible;

	void Start ()
	{
		invincible = false;		
	}

	public bool isInvincible()
	{
		return invincible;
	}

	public void damageTaken()
	{
		StartCoroutine (Invincibility (gracePeriod));
	}

	public void TurnInvincible(int invincibilityTime)
	{
		StartCoroutine (Invincibility (invincibilityTime));
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
}
