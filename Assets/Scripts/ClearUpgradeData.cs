using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class ClearUpgradeData : MonoBehaviour
{

	public Text infoText;

	public void clear()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/uppoints.sr"); 
		bf.Serialize(file, 0);
		file.Close();
		
		file = File.Create (Application.persistentDataPath + "/upvalues.sr"); 
		bf.Serialize(file, 1);
		bf.Serialize(file, 1);
		bf.Serialize(file, 1);
		file.Close();
		
		file = File.Create (Application.persistentDataPath + "/upmax.sr"); 
		bf.Serialize(file, 15);
		file.Close();

		infoText.text = "DATA CLEARED!";
	}
}
