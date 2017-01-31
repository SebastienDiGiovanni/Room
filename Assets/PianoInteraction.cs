using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoInteraction : MonoBehaviour {

	private GameObject piano;
	private BoxCollider pianoCollider;
	private bool playingPiano;
	private bool showStartPianoLabel;
	private bool showStopPianoLabel;

	// Use this for initialization
	void Start () {
		piano = GameObject.Find("piano");
		pianoCollider = piano.GetComponent<BoxCollider>();
		playingPiano = false;
		showStartPianoLabel = false;
		showStopPianoLabel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playingPiano == true)
		{
			if (showStopPianoLabel == false)
			{
				showStopPianoLabel = true;
			}
			if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton0))
			{
				piano.GetComponent<AudioSource>().Stop();
				playingPiano = false;
				showStopPianoLabel = false;
			}
		}
		else if (showStartPianoLabel == true && (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton0)))
		{
			piano.GetComponent<AudioSource>().Play();
			playingPiano = true;
			showStartPianoLabel = false;
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (other == pianoCollider && playingPiano == false)
		{
			if (showStartPianoLabel == false)
			{
				showStartPianoLabel = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other == pianoCollider && showStartPianoLabel == true)
		{
			showStartPianoLabel = false;
		}
    }
	
	void OnGUI() {
		if (showStartPianoLabel == true)
		{
			GUI.Label(new Rect(20, 10, 200, 40), "Press P (keyboard) or A (windows controller) to play piano !");
		}
		else if (showStopPianoLabel == true)
		{
			GUI.Label(new Rect(20, 10, 250, 40), "Press P (keyboard) or A (windows controller) to stop playing piano.");
		}
    }
}
