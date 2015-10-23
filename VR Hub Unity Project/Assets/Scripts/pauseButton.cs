using UnityEngine;
using System.Collections;

/* Pauses the music */
public class pauseButton : MonoBehaviour {

    public GameObject musicPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Activate() {
	
	  musicPlayer.GetComponent<AudioSource>().Pause();
	
	}
}
