using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	public GameObject pauseScreen;
	
	private Boolean paused;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !paused)
		{
			PauseGame();
			
		} else if (Input.GetKeyDown(KeyCode.Escape) && paused)
		{
			Unpause();
		}
		
	}

	public Boolean isPaused()
	{
		return paused;
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;
		paused = true;
			
		// Disables player movement
		GameObject player = GameObject.FindWithTag("Player");
		player.GetComponent<Movement>().enabled = false;
			
		// Shows Pause Screen
		pauseScreen.SetActive(true);
			
		// Enables Cursor
		Cursor.visible = true;
	}

	public void Unpause()
	{
		// Enables player movement
		GameObject player = GameObject.FindWithTag("Player");
		player.GetComponent<Movement>().enabled = true;
			
		// Disables Cursor
		Cursor.visible = false;
			
		// Hides Pause Screen
		pauseScreen.SetActive(false);
			
		Time.timeScale = 1f;
		paused = false;
	}
}
