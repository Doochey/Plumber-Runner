using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class loadUpgradeMenu : MonoBehaviour
{

	public GameObject gameOverCanvas;
	public GameObject upgradeMenu;
	public Text healthValue;
	public Text engineValue;
	public Text weaponValue;

	public void loadMenu()
	{
		upgradeMenu.SetActive(true);
		gameOverCanvas.SetActive(false); 
		loadValues();
		

	}


	public void unloadMenu()
	{
		saveValues();
		gameOverCanvas.SetActive(true);
		upgradeMenu.SetActive(false);
		
	}
	
	void saveValues()
	{
		int x = 0; 
		int.TryParse(healthValue.text, out x);
		int y = 0; 
		int.TryParse(engineValue.text, out y);
		int z = 0; 
		int.TryParse(weaponValue.text, out z);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/upvalues.sr"); 
		bf.Serialize(file, x);
		bf.Serialize(file, y);
		bf.Serialize(file, z);
		file.Close();
	}
	
	void loadValues()
	{
		if (File.Exists(Application.persistentDataPath + "/upvalues.sr"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/upvalues.sr", FileMode.Open);
			int x = (int)bf.Deserialize(file);
			healthValue.text = "" + x;
			int y = (int)bf.Deserialize(file);
			engineValue.text = "" + y;
			int z = (int)bf.Deserialize(file);
			weaponValue.text = "" + z;
			file.Close();
		}
		
	}
}
