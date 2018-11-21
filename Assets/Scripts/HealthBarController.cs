using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public GameObject player;
	public Slider healthBarSlider;

	void Start ()
	{
		healthBarSlider.maxValue = player.GetComponent<ShipHealth> ().getMaxHealth ();
	}

	void Update()
	{
		if (player != null)
		{
			healthBarSlider.value = player.GetComponent<ShipHealth> ().getHealth ();
		}
	}
}
