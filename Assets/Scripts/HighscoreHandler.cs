using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class HighscoreHandler : MonoBehaviour
{
	public ScoreCounter scoreCounter;
	public Text highscoresText;

	private int[] highscores = new int[10];

	void Start ()
	{
		//loads highscores into local list
		highscores = PlayerPrefsX.GetIntArray ("highscores");
		if (highscores.Length != 10)
		{
			highscores = new int[] {0,0,0,0,0,0,0,0,0,0};
			print ("Corrupt highscores, resetting.");
		}
	}

	//should be called at the end of a game, to update highscores
	public void gameEnd()
	{
		updateHighscores ();
		updateText ();

		//save highscores to disk
		PlayerPrefsX.SetIntArray ("highscores", highscores);
	}

	//updates local highscores with new score
	private void updateHighscores()
	{
		//sort and reverse to make sure list is in decending order
		Array.Sort (highscores);
		Array.Reverse (highscores);

		if (scoreCounter.getScore () > highscores [highscores.GetUpperBound(0)])
		{
			highscores [highscores.GetUpperBound(0)] = scoreCounter.getScore ();
			Array.Sort (highscores);
			Array.Reverse (highscores);
		}
	}

	//update on-screen text for highscores
	private void updateText()
	{
		String newString = "HIGHSCORES";
		int counter = 1;
		foreach (int score in highscores)
		{
			newString += "\n" + counter + ". " + score;
			counter++;
		}
		highscoresText.text = newString;
	}
}
