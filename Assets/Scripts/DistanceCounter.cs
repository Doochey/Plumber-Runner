using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
	public GameObject player;
	public int startingDistance;

	private int distanceCount;
	private int engineValue;

	void Start ()
	{
		distanceCount = startingDistance;
		engineValue = GameObject.FindWithTag("GameController").GetComponent<UpgradeHandler>().getValues()[1];
	}
	
	void Update ()
	{
		if (player != null)
		{
			distanceCount += (int) (100 * (1 + engineValue / 5) * Time.deltaTime);
		}
	}

	public int GetDistance()
	{
		return distanceCount;
	}
}
