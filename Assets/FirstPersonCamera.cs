using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				Camera.main.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				Camera.main.transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				Camera.main.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				Camera.main.transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
			}
		}
	}
}
