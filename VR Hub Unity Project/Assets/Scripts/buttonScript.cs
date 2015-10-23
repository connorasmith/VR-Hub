using UnityEngine;
using System.Collections;

/* Script that should be placed on each button to allow easy music playing */
public class buttonScript : MonoBehaviour {

	public GameObject buttonText; //drag in the button text 
	public GameObject musicPlayer; //drag in the music player
	
	public int buttonNum; //what button number is this one?

	public AudioClip buttonAudio; //attach audio

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* Method that will play the music - called from the music player */
	public void playMusic() {
	
	  //sets the current clip to this button
	  musicPlayer.GetComponent<AudioSource>().clip = buttonAudio;
	  musicPlayer.GetComponent<AudioSource>().Play(); //play music
	
	}
}
