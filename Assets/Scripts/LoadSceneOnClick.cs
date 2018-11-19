using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public GameObject laserSound;

    public void LoadSceneByIndex(int sceneIndex)
	{
        GameObject makeSound = Instantiate(laserSound, this.transform.position, this.transform.rotation) as GameObject;
        SceneManager.LoadScene(sceneIndex);
	}
}
