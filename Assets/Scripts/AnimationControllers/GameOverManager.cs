using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public GameObject player;
	public HighscoreHandler highscoresHandler;

	private Animator anim;
	private bool gameOver;

	void Start ()
	{
		gameOver = false;
		anim = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
		if (player == null && !gameOver)
		{
			gameOver = true;
			anim.SetTrigger("GameOver");
			highscoresHandler.gameEnd ();
		}
	}
}
