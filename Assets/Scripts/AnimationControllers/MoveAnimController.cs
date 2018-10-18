using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimController : MonoBehaviour {
	

	private Animator anim;

	
	//TODO
	//BROKEN
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		
	}
	
	void Update () {
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				anim.SetTrigger("MoveUp");
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				anim.SetTrigger("MoveDown");
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				anim.SetTrigger("MoveLeft");
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				anim.SetTrigger("MoveRight");
			}
		}
		else
		{
			anim.SetTrigger("Return");
		}
		
		

		
	}
}
