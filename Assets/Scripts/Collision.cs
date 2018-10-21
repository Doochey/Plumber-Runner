using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

	private static Boolean played = false;
	
	void OnTriggerEnter(Collider other)
	{
		if (!played)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				var exp = other.gameObject.GetComponent<ParticleSystem>();
				exp.Play();
			
				Destroy(other.gameObject, exp.main.duration);
				played = true;

				//other.gameObject.SetActive(false);

			}
		}
		
	}
}
