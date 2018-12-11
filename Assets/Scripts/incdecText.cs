using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incdecText : MonoBehaviour
{

	public Text valueText;
	public Text pointsLeft;
	private static int points;
	private UpgradeHandler upgradeHandler;

	void Start()
	{
		upgradeHandler = GameObject.FindWithTag("GameController").GetComponent<UpgradeHandler>();
		points = upgradeHandler.getPoints();
		pointsLeft.text = "POINTS LEFT: " + points;
	}

	public void inc()
	{
		
		int value = 0; 
		int.TryParse(valueText.text, out value);
		if (value < 6)
		{
			if (points != 0)
			{
				value++;
				valueText.text = "" + value;
				points--;
				upgradeHandler.decreasePoints();
				pointsLeft.text = "POINTS LEFT: " + points;
			}
			
		}
		
	}

	public void dec()
	{
		int value = 0; 
		int.TryParse(valueText.text, out value);
		if (value > 1 && points < 15)
		{
			value--;
			valueText.text = "" + value;
			points++;
			upgradeHandler.increasePoints();
			pointsLeft.text = "POINTS LEFT: " + points;
			
		}
	}
	
	
	
}
