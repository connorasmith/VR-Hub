using UnityEngine;
using System.Collections;

/* Stops the music from playing */
public class stopButton : MonoBehaviour {

    public GameObject musicPlayer; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Activate() {
	
	  musicPlayer.GetComponent<AudioSource>().Stop ();
	
	}
}
