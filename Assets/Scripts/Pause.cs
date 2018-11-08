using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	private Boolean paused;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && !paused)
		{
			
			Time.timeScale = 0f;
			paused = true;
			
			// Disables player movement
			GameObject player = GameObject.FindWithTag("Player");
			player.GetComponent<Movement>().enabled = false;

		} else if (Input.GetKeyDown(KeyCode.Alpha1) && paused)
		{
			// Enables player movement
			GameObject player = GameObject.FindWithTag("Player");
			player.GetComponent<Movement>().enabled = true;
			
			Time.timeScale = 1f;
			paused = false;
			
			
		}
		
	}
}
