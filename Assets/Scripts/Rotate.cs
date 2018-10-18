using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	
	
	public float rotateMin = 0f;
	public float rotateMax = 200f;
	
	private Vector3 rotation;
	private Vector3 r;
	
	// Update is called once per frame
	private void Start()
	{
		r = generateRotation();
	}

	void Update () {
		
		
		transform.Rotate (r * Time.deltaTime);
	}

	private Vector3 generateRotation()
	{
		// Generates random rotation
		float rx = Random.Range(rotateMin, rotateMax);
		float ry = Random.Range(rotateMin, rotateMax);
		float rz = Random.Range(rotateMin, rotateMax);
		int plusOrMinus = Random.Range(0, 1);
		if (plusOrMinus == 0)
		
		rotation = new Vector3(rx,ry,rz);
		
		return rotation;
		
		

		
	}
}
