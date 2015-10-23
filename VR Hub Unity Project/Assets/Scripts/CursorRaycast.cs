using UnityEngine;
using System.Collections;

/* This script is the gaze system that allows the user to
 * interact with objects simply by looking around.
 * To use, make sure that the interactable object has
 * a script tag called "InteractEye" on it, unless
 * otherwise specified
 */
public class CursorRaycast : MonoBehaviour {

  public static GameObject cursorObject; //the gaze cursor

  private Ray gazeRay; //this will be the ray used for raycasting
  RaycastHit targetedEye; //button that's looked at
  private Animator cursorAnimator; //cursor animation
  
  private bool looking = false; //checks if the user is looking at a button
  private bool alreadyActivated = false; //checks if animation was activated 
  
  private string animBool = "activateCursor"; //boolean tag on the animator

  // Use this for initialization
  void Start () {
  
    cursorObject = this.gameObject; //makes this object accessible from all other scripts
    cursorAnimator = GetComponent<Animator>(); //sets the animator
	
  }
	
  // Update is called once per frame
  void Update () {
	
	//creates new ray for raycast
    gazeRay = new Ray (this.transform.position, this.transform.forward);
	
	//performs Raycast infinitely forward, stores hit objects into targetedEye
	if (Physics.Raycast(gazeRay, out targetedEye, Mathf.Infinity)) {
	   
	  //checks the tag of the hit object - should be InteractEye
	  if (targetedEye.collider.tag == "InteractEye") {
	  
	    //if the animation hasn't already been activated
	    if (alreadyActivated == false) {
	      looking = true; //user is looking
	      cursorAnimator.SetBool (animBool, true); //start animation
	    }
	  }
	  
	  //deactivate the cursor animation if the user looks at something else
	  else {
	  
	    DeactivateCursor();
	    
	  }
	}
	
	//deactivate the cursor animation if the user looks at nothing
    else {
	
      DeactivateCursor();
	  
	}

    //If the user looked at the object for the full cursor animation (95% of it, at least)
	if (looking == true && cursorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95) {
		
	  //send Activate message to the object
	  targetedEye.collider.gameObject.SendMessage("Activate");
	  
	  DeactivateCursor(); //deactivate the cursor
	  
	  alreadyActivated = true; //cursor has been activated- animation wont auto run again
	  cursorAnimator.speed = 0; //stop the cursor animation
	      
	}	
  }
  
  /* Deactivates the cursor by setting it back toward the beginning */
  void DeactivateCursor() {
 
    looking = false; //user not looking
    cursorAnimator.Play (0); //start over
    cursorAnimator.SetBool (animBool, false); //set bool flag to false
    alreadyActivated = false; //cursor is not activated
    cursorAnimator.speed = 1; //set speed back to normal
 
  
  }
}
