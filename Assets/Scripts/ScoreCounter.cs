using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	public Text scoreText;
	public GameObject player;
	public GameObject multiplierObject;
	public int startingScore;

	private int scoreCount;
	private MultiplierCounter multiplier;

	void Start ()
	{
		scoreCount = startingScore;
		multiplier = multiplierObject.GetComponent<MultiplierCounter>();
		scoreText.text = "SCORE: " + scoreCount.ToString();
	}

	void Update ()
	{
		if (player != null)
		{
			scoreCount += (int) (100 * Time.deltaTime) * multiplier.GetMultiplier();
			scoreText.text = "SCORE: " + scoreCount.ToString();
		}
	}

	public void Bonus(int bonusAmount)
	{
		scoreCount += bonusAmount * multiplier.GetMultiplier();
	}
}