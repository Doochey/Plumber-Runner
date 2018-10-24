using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierCounter : MonoBehaviour
{
	public Text multiplierText;
	public GameObject player;
	public int startingMultiplier;

	private int multiplierCount;

	void Start ()
	{
		multiplierCount = startingMultiplier;
		multiplierText.text = "MULTIPLIER: " + multiplierCount.ToString();
	}

	void Update ()
	{
		if (player != null)
		{
			multiplierText.text = "MULTIPLIER: " + multiplierCount.ToString() + "x";
		}
	}

	public void increaseMultiplier(int increase)
	{
		multiplierCount += increase;
	}

	public int GetMultiplier ()
	{
		return multiplierCount;
	}
}