using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierCounter : MonoBehaviour
{
	public GameObject player;
	public int startingMultiplier;

	private int multiplierCount;

	void Start ()
	{
		multiplierCount = startingMultiplier;
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