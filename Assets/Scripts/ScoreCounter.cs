using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	public GameObject player;
	public MultiplierCounter multiplier;
	public int startingScore;

	private int scoreCount;

	void Start ()
	{
		scoreCount = startingScore;
	}

	void Update ()
	{
		if (player != null)
		{
			scoreCount += (int) (100 * Time.deltaTime) * multiplier.GetMultiplier();
		}
	}

	public void Bonus(int bonusAmount)
	{
		scoreCount += bonusAmount * multiplier.GetMultiplier();
	}

	public int getScore()
	{
		return scoreCount;
	}
}