using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
	private float horizontalSpeed = 0.3f;
	private float VerticalSpeed = 0.3f;

	void Start ()
	{
		Cursor.visible = false;
	}
	
	void Update ()
	{
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
		pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
		transform.position = Camera.main.ViewportToWorldPoint(pos);

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
		{
			transform.Translate(0, 0.1f, 0);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0, -0.1f, 0);
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-0.1f, 0, 0);
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(0.1f, 0, 0);
		}

		if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
		{
			float hs = horizontalSpeed * Input.GetAxis("Mouse X");
			float vs = VerticalSpeed * Input.GetAxis("Mouse Y");
			transform.Translate(hs, vs, 0);
		}

		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(1);
		}

#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.LeftShift))
		{
			transform.Translate(0, 0, 0.1f);
		}
		
		if (Input.GetKey(KeyCode.LeftControl))
		{
			transform.Translate(0, 0, -0.1f);
		}
#endif
		
	}

	
}
