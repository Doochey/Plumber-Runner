using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
	public GameObject player;
	public int startingDistance;

	private int distanceCount;

	void Start ()
	{
		distanceCount = startingDistance;
	}
	
	void Update ()
	{
		if (player != null)
		{
			distanceCount += (int) (100 * Time.deltaTime);
		}
	}

	public int GetDistance()
	{
		return distanceCount;
	}
}
