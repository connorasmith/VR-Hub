using UnityEngine;
using System.Collections;

/* This is the initial eye on the welcome screen */
public class WelcomeEye : MonoBehaviour {

    public GameObject welcomePlane; //starting plane
 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* Called by gaze system */
	public void Activate() {
	
	  //starts the fadeout if the eye is looked at, and destroys the collider
	  welcomePlane.SendMessage ("CommenceFadeOut");
	  GetComponent<SphereCollider>().radius = 0;
	
      
	
  }
}
