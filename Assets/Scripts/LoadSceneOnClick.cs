using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public GameObject laserSound;
	public Pause pause;

    public void LoadSceneByIndex(int sceneIndex)
	{
		if (SceneManager.GetActiveScene().buildIndex == sceneIndex || sceneIndex == 0)
		{
			if (pause.isPaused())
			{
				pause.Unpause();
			}
			
			
			
		}
        GameObject makeSound = Instantiate(laserSound, this.transform.position, this.transform.rotation) as GameObject;
        SceneManager.LoadScene(sceneIndex);
		
		if (sceneIndex == 0)
		{
			// Enables Cursor
			Cursor.visible = true;
		}
	}
}
