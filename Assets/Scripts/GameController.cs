using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public HighscoreHandler highscoresHandler;
	public Canvas HUDCanvas;
	public Canvas GameOverCanvas;

	private Animator anim;
	private bool gameOver;

	private Text HUDDistance;
	private Text HUDScore;
	private Text HUDMultiplier;
	private Text GODistance;
	private Text GOScore;
	private Text GOMultiplier;

	void Start ()
	{
		gameOver = false;
		GameOverCanvas.enabled = false;
		HUDCanvas.enabled = true;
		anim = GameOverCanvas.GetComponent<Animator>();
		Cursor.visible = false;

		//find text components
		HUDDistance = HUDCanvas.transform.Find ("Distance Text").GetComponent<Text> ();
		HUDScore = HUDCanvas.transform.Find ("Score Text").GetComponent<Text> ();
		HUDMultiplier = HUDCanvas.transform.Find ("Multiplier Text").GetComponent<Text> ();
		GODistance = GameOverCanvas.transform.Find("Panel2").Find ("Distance Text").GetComponent<Text> ();
		GOScore = GameOverCanvas.transform.Find("Panel2").Find ("Score Text").GetComponent<Text> ();
		GOMultiplier = GameOverCanvas.transform.Find("Panel2").Find ("Multiplier Text").GetComponent<Text> ();
	}

	void Update ()
	{
		if (player == null && !gameOver)
		{
			GameOver ();
		}
		UpdateHUD ();
	}

	void GameOver()
	{
		gameOver = true;
		GameOverCanvas.enabled = true;
		HUDCanvas.enabled = false;
		anim.SetTrigger("GameOver");
		highscoresHandler.gameEnd ();
		Cursor.visible = true;

		//update game over texts
		GODistance.text = "DISTANCE: " + gameObject.GetComponent<DistanceCounter>().GetDistance() + "m";
		GOScore.text = "SCORE: " + gameObject.GetComponent<ScoreCounter>().getScore();
		GOMultiplier.text = "MAX MULTIPLIER: " + gameObject.GetComponent<MultiplierCounter>().GetMultiplier() + "x";
	}

	//should be called every tick to keep changing HUD elements
	void UpdateHUD()
	{
		HUDDistance.text = "DISTANCE: " + gameObject.GetComponent<DistanceCounter>().GetDistance() + "m";
		HUDScore.text = "SCORE: " + gameObject.GetComponent<ScoreCounter>().getScore();
		HUDMultiplier.text = "MULTIPLIER: " + gameObject.GetComponent<MultiplierCounter>().GetMultiplier() + "x";
	}

}
