using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

	public GameObject player;

	private Animator anim;

	void Start () {
		anim = gameObject.GetComponent<Animator>();
		
	}
	
	void Update () {
		if (player == null)
		{
			anim.SetTrigger("GameOver");
		}
	}
}
