using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimController : MonoBehaviour {
	

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
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
