using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

	
	
	private static Boolean played = false;

	public void reset()
	{
		played = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!played)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				
				// Disables player movement
				other.gameObject.GetComponent<Movement>().enabled = false;
				
				// Disable distance Counter
				GameObject[] distanceCounters = GameObject.FindGameObjectsWithTag("Counter");
				foreach (GameObject dc in distanceCounters)
				{
					dc.GetComponent<DistanceCounter>().setHalt();
				}
				
				// Disables mesh renderer of player object making them invisible
				Renderer rend = other.gameObject.GetComponent<Renderer>();
				rend.enabled = false;
				
				
				// Disables all children of the player object
				foreach (Transform child in other.gameObject.transform)
				{
					child.gameObject.SetActive(false);
				}
				
				// Plays explosion particle effect
				var exp = other.gameObject.GetComponent<ParticleSystem>();
				exp.Play();
				
			
				// Destroys player object after explosion duration
				Destroy(other.gameObject, exp.main.duration);
				played = true;



			}
		}
		
	}
}