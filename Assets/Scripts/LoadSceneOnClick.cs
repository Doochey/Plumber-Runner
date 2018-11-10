using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

	public Pause pause;

	public void LoadSceneByIndex(int sceneIndex)
	{
		
		if (SceneManager.GetActiveScene().buildIndex == sceneIndex || sceneIndex == 0)
		{
			if (pause.isPaused())
			{
				pause.Unpause();
			}
			Reset();
			
			
			
		}
		SceneManager.LoadScene(sceneIndex);

		if (sceneIndex == 0)
		{
			// Enables Cursor
			Cursor.visible = true;
		}
	}

	void Reset()
	{
		GameObject colliderObject = GameObject.FindWithTag("Enemy");
		colliderObject.GetComponent<Collision>().reset();
	}
}
