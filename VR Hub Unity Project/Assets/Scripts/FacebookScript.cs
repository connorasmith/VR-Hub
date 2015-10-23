using UnityEngine;
using System.Collections;

/* This script creates the Facebook Screen if activated */
public class FacebookScript : MonoBehaviour {

    public Object facebookObject; //drag object that should be created
    private GameObject facebookScreen; 
    
    private bool activated = false; //checks if the screen has been activated

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	/* Called by the Gaze System */
	void Activate() {
	
	  //if it hasn't ben activated yet
	  if (!activated) {
	
	    //sets proper rotation that it should start at
	    Quaternion screenRotation = new Quaternion(0.0f, 0.7f, -0.7f, 0.0f);
	    
	    //Creates screen at an offset of 7 fromthe camera
	    Vector3 screenLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
	    
	    //Creates the actual facebook screen
		facebookScreen = (GameObject) GameObject.Instantiate (facebookObject, screenLocation, screenRotation);
		
		//Sets the position of the screen
		facebookScreen.transform.position = new Vector3(0,0,7);
		
		//screen was activated
		activated = true;
		
      }
      
      //if it was already activated, destroy the screen
      else {
      
        GameObject.Destroy (facebookScreen);
        activated = false;
      
      }
	}
}
