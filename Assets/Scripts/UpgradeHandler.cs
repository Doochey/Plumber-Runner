using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour {

	public GameObject player;
	public int scoreDivisor = 1000;
	public Text upgradePoints;


	private int currentPoints = 0;
	private int distanceCount;
	private int score;
	private bool gameOver;
	private int maxPoints = 15;

	void Start ()
	{
	}
	
	void Update ()
	{
		if (player != null)
		{
			score = gameObject.GetComponent<ScoreCounter>().getScore();
			
		}
		else
		{
			getPoints();
			if (score / scoreDivisor >= 1 && !gameOver)
			{
				loadMax();
				getPoints();
				currentPoints = currentPoints + (score / scoreDivisor);
				if (currentPoints > maxPoints)
				{
					currentPoints = maxPoints;
				}
				gameOver = true;
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Create (Application.persistentDataPath + "/uppoints.sr"); 
				bf.Serialize(file, currentPoints);
				file.Close();
				upgradePoints.text = "UPGRADE POINTS: " + currentPoints;
			}
			else
			{
				
				upgradePoints.text = "UPGRADE POINTS: " + currentPoints;
			}
		}
	}

	public int getPoints()
	{
		if (File.Exists(Application.persistentDataPath + "/uppoints.sr"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/uppoints.sr", FileMode.Open);
			currentPoints = (int)bf.Deserialize(file);
			file.Close();
			if (currentPoints > maxPoints)
			{
				currentPoints = maxPoints;
			}

			upgradePoints.text = "UPGRADE POINTS: " + currentPoints;
		}
		
		return currentPoints;
	}

	public void decreasePoints()
	{
		if (currentPoints > 0)
		{
			currentPoints--;
			maxPoints--;
			saveMax();
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (Application.persistentDataPath + "/uppoints.sr"); 
			bf.Serialize(file, currentPoints);
			file.Close();
			upgradePoints.text = "UPGRADE POINTS: " + currentPoints;
		}
	}
	
	public void increasePoints()
	{
		if (currentPoints < maxPoints)
		{
			currentPoints++;
			maxPoints++;
			saveMax();
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (Application.persistentDataPath + "/uppoints.sr"); 
			bf.Serialize(file, currentPoints);
			file.Close();
			upgradePoints.text = "UPGRADE POINTS: " + currentPoints;
		}
	}

	public void loadMax()
	{
		if (File.Exists(Application.persistentDataPath + "/upmax.sr"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/upmax.sr", FileMode.Open);
			maxPoints = (int)bf.Deserialize(file);
			file.Close();
		}
		
	}

	public void saveMax()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/upmax.sr"); 
		bf.Serialize(file, maxPoints);
		file.Close();
	}

	public int[] getValues()
	{
		int[] values = new int[3];
		values[0] = 1;
		values[1] = 1;
		values[2] = 1;
		
		if (File.Exists(Application.persistentDataPath + "/upvalues.sr"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/upvalues.sr", FileMode.Open);
			
			int x = (int)bf.Deserialize(file);
			values[0] = x;
			int y = (int)bf.Deserialize(file);
			values[1] = y;
			int z = (int)bf.Deserialize(file);
			values[2] = z;
			file.Close();
		}
		return values;
	}

	

	

	
}
