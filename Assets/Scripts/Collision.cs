using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			var exp = other.gameObject.GetComponent<ParticleSystem>();
			exp.Play();
			
			Destroy(other.gameObject, exp.main.duration);
			//other.gameObject.SetActive(false);
		


		}
	}
}
