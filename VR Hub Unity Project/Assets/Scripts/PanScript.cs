using UnityEngine;
using System.Collections;

/* Allows the user to drag screens and drop them */
public class PanScript : MonoBehaviour {

    public GameObject panScreen; //the screen that can be panned
    public GameObject cursor; //the user cursor
    
    private float dropTime = 50; //how long the user must wait to drop screens
    
    private float dropThreshold = 1f; // how much the user is allowed to move the screen
                                      // for this to be considered a "drop"
    private float dropTimer = 0; //the drop timer that will increment
    private Vector3 previousPosition; //previous location of the screen

	// Use this for initialization
	void Start () {
	
	  previousPosition = panScreen.transform.position; //starts at initial position
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  //if the user isnt moving the screen much, increment the drop timer
	  if (Vector3.Distance (panScreen.transform.position, previousPosition) < dropThreshold) {
	  
	    dropTimer++;
	    
	  
	  }
	  
	  //if the user moved the window more than the threshold, reset the drop timer and position
	  else {
	  
	    dropTimer = 0;
	    previousPosition = panScreen.transform.position;
	    
	  }
	  
	  //if the timer completes, free the music player from user control
	  if (dropTimer == dropTime) {
	  
	    panScreen.transform.parent = null;
	  
	  }
	}
	
	/* Called by gaze system */
	void Activate() {
	
	  //Attaches screen to the cursor, such that screen will move with user gaze
	  panScreen.transform.parent = CursorRaycast.cursorObject.transform;
	  previousPosition = panScreen.transform.position;
	
	}
	
}
