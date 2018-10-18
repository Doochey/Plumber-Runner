using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
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
