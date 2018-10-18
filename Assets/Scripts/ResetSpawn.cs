using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
	private Vector3 origin;

	public float randRange = 20f;
	public float minSize = 1f;
	public float maxSize = 1f;

	void Start()
	{
		origin = gameObject.transform.position;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("despawner"))
		{
			
			// Resets asteroid to random location around its initial origin
			float x = Random.Range(origin.x - randRange, origin.x + randRange);
			float y = Random.Range(origin.y - randRange, origin.y + randRange);
			float z = Random.Range(origin.z - randRange, origin.z + randRange);
			transform.position = new Vector3(x, y, z);

			float sx = Random.Range(minSize, maxSize);
			float sy = Random.Range(minSize, maxSize);
			float sz = Random.Range(minSize, maxSize);
			transform.localScale = new Vector3(sx, sy, sz);


		}
	}
}
