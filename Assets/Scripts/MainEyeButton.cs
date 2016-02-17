using UnityEngine;
using System.Collections;

/* This is the main button visible at the start of the workspace scene
 * Activating this button will float out the other button options
 * Think of it like the "Start" button on a Windows computer 
 */
public class MainEyeButton : MonoBehaviour {

    public Object musicButton; //music button
    public Object facebookButton; //facebook button
    public Object youtubeButton; //youtube button
    public Object themeButton; //theme button
    
    //stored buttons after they're created
    private GameObject activeMusicButton;
    private GameObject activeFacebookButton;
    private GameObject activeYoutubeButton;
    private GameObject activeThemeButton;
    
    public float wheelRadius; //how much should buttons be spread out
    
    public float fadeSpeed; //how fast should buttons fade
    public float speed = 1.0f; //lerp speed for when the buttons float

    private bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//called from gaze system
	void Activate() {
	
	  //if the button hasn't already been activated
	  if (!activated) {
	
	    //creates all the buttons, moves them to respective locations, and fades them in
        activeMusicButton = (GameObject) GameObject.Instantiate (musicButton, this.transform.position, this.transform.rotation);
	    StartCoroutine(MoveToPosition(activeMusicButton, 1));
	    StartCoroutine(FadeIn (activeMusicButton.GetComponent<SpriteRenderer>().material, fadeSpeed));
	    
	    activeFacebookButton = (GameObject) GameObject.Instantiate(facebookButton, this.transform.position, this.transform.rotation);
	    StartCoroutine (MoveToPosition (activeFacebookButton, 2));
	    StartCoroutine (FadeIn(activeFacebookButton.GetComponent<SpriteRenderer>().material, fadeSpeed));
	    
	    activeYoutubeButton = (GameObject) GameObject.Instantiate(youtubeButton, this.transform.position, this.transform.rotation);
	    StartCoroutine(MoveToPosition(activeYoutubeButton, 3));
		StartCoroutine (FadeIn(activeYoutubeButton.GetComponent<SpriteRenderer>().material, fadeSpeed));
		
	    activeThemeButton = (GameObject) GameObject.Instantiate(themeButton, this.transform.position, this.transform.rotation);
	    StartCoroutine(MoveToPosition(activeThemeButton, 4));
		StartCoroutine (FadeIn(activeThemeButton.GetComponent<SpriteRenderer>().material, fadeSpeed));
	    
	    activated = true;
	    
	  }
	  
	  //floats the buttons back
	  else {
	  
	    StartCoroutine(MoveFromPosition(activeMusicButton, 1));
	    StartCoroutine (MoveFromPosition (activeFacebookButton, 2));
		StartCoroutine (MoveFromPosition (activeYoutubeButton, 3));
	    StartCoroutine (MoveFromPosition (activeThemeButton, 4));
	  
	  
	  }
	}
	
	//moves the objects to their locations on the application wheel
	IEnumerator MoveToPosition(GameObject movableObject, int buttonNum) {
	
	  //gets the position of the current eye button
	  Vector3 button = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	
	  //if it's the first button
	  if (buttonNum == 1) {
	  
	    //move it +wheelRadius on the x axis
	    button = new Vector3(transform.position.x + wheelRadius, transform.position.y, transform.position.z);
	  }
	  
	  //if it's the second button
	  if (buttonNum == 2) {
	  
	    //move it -wheelRadius on the x axis
	    button = new Vector3(transform.position.x - wheelRadius, transform.position.y, transform.position.z);
	  
	  }
	  
	  //if it's the third button
	  if (buttonNum == 3) {
	  
	    //move it -wheelRadius on the y axis
	    button = new Vector3(transform.position.x, transform.position.y - wheelRadius, transform.position.z);
	  
	  }
	  
	  //if it's the fourth button
	  if (buttonNum == 4) {
	  
	    //move it +wheelRadius on the y axis
	    button = new Vector3(transform.position.x, transform.position.y + wheelRadius, transform.position.z);
	  
	  }
	  
	  //moves the object slowly across each frame, at speed
      for (float i=0.0f; i<speed; i+=Time.deltaTime ) {
			
        //lerps the position of the object at an increasing distance across each frame
	    movableObject.transform.position = Vector3.Lerp (transform.position, button, i/speed);
	  
	    yield return null;
	      
	  }
	}
	
	//moves the buttons back to their original position
	IEnumerator MoveFromPosition(GameObject movableObject, int buttonNum) {
	
	  //stores center position
	  Vector3 button = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	  
	  //gets the position of all the other buttons
	  if (buttonNum == 1) {
	  
	    button = new Vector3(transform.position.x + wheelRadius, transform.position.y, transform.position.z);
	    
	  }
	  
	  if (buttonNum == 2) {
	  
	    button = new Vector3(transform.position.x - wheelRadius, transform.position.y, transform.position.z);
	  
	  }
	  
	  if (buttonNum == 3) {
	  
		button = new Vector3(transform.position.x, transform.position.y - wheelRadius, transform.position.z);
	  
	  }
	  
	  if (buttonNum == 4) {
	  
	    button = new Vector3(transform.position.x, transform.position.y + wheelRadius, transform.position.z);
	  
	  }
	  	  
	  //moves all the buttons back to the center location
	  for (float i=0.0f; i<speed; i+=Time.deltaTime ) {
			
	      movableObject.transform.position = Vector3.Lerp (button, transform.position, i/speed);
	  
	      yield return null;
	      
	      
	  }
	  
		GameObject.Destroy(movableObject); //destroys the buttons
		activated = false;
	}
	
	//fades the buttons in as well
	IEnumerator FadeIn(Material material, float fadeSpeed) {
	 
	  Color tempColor = material.color;
	  tempColor.a = 0;
	  material.SetColor ("_Color", tempColor);
	  
	
	  while (material.color.a < 1) {
	  
	    tempColor.a += fadeSpeed;
	    material.SetColor ("_Color", tempColor);
	    
	    yield return null;
	  
	  }
	}
}
