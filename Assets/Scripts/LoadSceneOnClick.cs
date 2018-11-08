using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadSceneByIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
		if (SceneManager.GetActiveScene().name == "Blue Lagoon Nebula")
		{
			GameObject colliderObject = GameObject.FindWithTag("Enemy");
			colliderObject.GetComponent<Collision>().reset();
		}
	}
}
