using UnityEngine;
using System.Collections;

/* Plays the music - or rather, "unpauses" it */
public class playButton : MonoBehaviour {

    public GameObject musicPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Activate() {
	
	  musicPlayer.GetComponent<AudioSource>().UnPause ();
	
	}
}
