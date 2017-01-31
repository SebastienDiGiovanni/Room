using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightInteraction : MonoBehaviour {

	private GameObject light;
	private BoxCollider lightCollider;
	private bool on;
	private bool showOnLabel;
	private bool showOffLabel;

	// Use this for initialization
	void Start () {
		light = GameObject.Find("Light0");
		lightCollider = light.GetComponent<BoxCollider>();
		on = true;
		showOnLabel = false;
		showOffLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerStay(Collider other) {
		if (other == lightCollider)
		{
			if (on == true)
			{
				if (showOffLabel == false)
				{
					showOffLabel = true;
				}
				if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton0))
				{
					light.GetComponent<Light>().intensity = 0;
					on = false;
					showOffLabel = false;
				}
			}
			else
			{
				if (showOnLabel == false)
				{
					showOnLabel = true;
				}
				if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.JoystickButton0))
				{
					light.GetComponent<Light>().intensity = 1;
					on = true;
					showOnLabel = false;
				}
			}	
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other == lightCollider)
		{
			if (showOnLabel == true)
			{
				showOnLabel = false;
			}
			if (showOffLabel == true)
			{
				showOffLabel = false;
			}
		}
    }
	
	void OnGUI() {
		if (showOnLabel == true)
		{
			GUI.Label(new Rect(20, 10, 250, 40), "Press L (keyboard) or A (windows controller) to switch on the light.");
		}
		else if (showOffLabel == true)
		{
			GUI.Label(new Rect(20, 10, 250, 40), "Press L (keyboard) or A (windows controller) to switch off the light.");
		}
    }
}
