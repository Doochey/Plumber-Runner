using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{

	public Text distanceText;
	public GameObject player;

	private int distanceCount = 0;

	// Use this for initialization
	void Start ()
	{
		distanceText.text = "DISTANCE: " + distanceCount.ToString() + "m";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player != null)
		{
			distanceCount = distanceCount + (int) (100 * Time.deltaTime);
			distanceText.text = "DISTANCE: " + distanceCount.ToString() + "m";
		}
		
	}
}
