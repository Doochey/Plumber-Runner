using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
	public GameObject player;
	public Slider healthBar;

	void Start ()
	{
		healthBar.maxValue = player.GetComponent<ShipHealth> ().getMaxHealth ();
	}

	void Update ()
	{
		
	}

	public void updateHealth()
	{
		healthBar.value = player.GetComponent<ShipHealth> ().getHealth ();
	}
}
