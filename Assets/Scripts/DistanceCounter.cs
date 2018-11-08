using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
	public Text distanceText;
	public GameObject player;

	private int distanceCount = 0;
	private Boolean halt;

	void Start ()
	{
		distanceText.text = "DISTANCE: " + distanceCount.ToString() + "m";
	}
	
	void Update ()
	{
		if (!halt)
		{
			distanceCount += (int) (100 * Time.deltaTime);
			distanceText.text = "DISTANCE: " + distanceCount.ToString() + "m";
		}
	}


	public void setHalt()
	{
		halt = true;
	}
}
