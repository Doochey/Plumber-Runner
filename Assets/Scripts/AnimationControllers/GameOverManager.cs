using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

	public GameObject player;
	public GameObject gameOverScreen;
	public HighscoreHandler highscoresHandler;

	private Animator anim;
	private bool gameOver;
	
	void Start()
	{
		gameOver = false;
		anim = gameObject.GetComponent<Animator>();

	}

	void Update()
	{
		if (player == null && !gameOver)
		{
			gameOver = true;
			gameOverScreen.SetActive(true);
			anim.SetTrigger("GameOver");
			highscoresHandler.gameEnd ();
			
			// Enables Cursor
			Cursor.visible = true;
		}
	}
}