using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public GameObject gameController;
	public Slider healthBarSlider;

	void Start ()
	{
		healthBarSlider.maxValue = gameController.GetComponent<DamageHandler> ().getMaxHealth ();
	}

	void Update()
	{
		healthBarSlider.value = gameController.GetComponent<DamageHandler> ().getHealth ();
	}
}
