using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class HighscoreHandler : MonoBehaviour
{
	public GameObject scoreText;
	public Text highscoresText;

	private int[] highscores = new int[10];
	private ScoreCounter scoreCounter;

	void Start ()
	{
		scoreCounter = scoreText.GetComponent<ScoreCounter>();
		highscores = PlayerPrefsX.GetIntArray ("highscores");
	}

	public void gameEnd()
	{
		updateHighscores ();
		updateText ();
		PlayerPrefsX.SetIntArray ("highscores", highscores);
	}

	private void updateHighscores()
	{
		if (scoreCounter.getScore () > highscores [highscores.GetUpperBound(0)])
		{
			highscores [highscores.GetUpperBound(0)] = scoreCounter.getScore ();
		}

		Array.Sort (highscores);
		Array.Reverse (highscores);
	}

	private void updateText()
	{
		String newString = "HIGHSCORES";
		int counter = 0;
		foreach (int score in highscores)
		{
			print (score);
			newString += "\n" + counter + ". " + score;
			counter++;
		}
		highscoresText.text = newString;
	}
}
