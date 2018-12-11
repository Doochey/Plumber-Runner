using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var main = gameObject.GetComponent<ParticleSystem>().main;
		main.startSpeedMultiplier = main.startSpeedMultiplier +
		                            2 * GameObject.FindWithTag("GameController").GetComponent<UpgradeHandler>().getValues()[
			                            1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
