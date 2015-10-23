using UnityEngine;
using System.Collections;

/* Allows for easy fading of planes, or anything else honestly
 * Only used in this context for creating the opening screen
 */
public class FadeScript : MonoBehaviour {

    private Material planeMaterial; //material of plane
    private Material openingText; //text that should appear
    private Material interactableEye; // eye that users can interact with
    private Material instructions; //opening instructions
    
    public GameObject openingTextObject; // actual object for opening text
    public GameObject startingEye; // object for interactable eye
    public GameObject instructionsObject; // object for the instructions
    
    public float fadeSpeed; //set how fast things should fade
    
    //variables that keep track if fading is complete
    private bool planeComplete = false; 
    private bool textComplete = false;
    private bool eyeComplete = false;
    private bool instructionsComplete = false;
    
    private bool commenceFadeOut = false; //fade out when necessary

	// Use this for initialization
	void Start () {
	
	  planeMaterial = GetComponent<MeshRenderer>().material; //grabs material
	  Color tempColor = planeMaterial.color; //stores material
	  tempColor.a = 0.0f; //changes transparency of material to full
	  planeMaterial.SetColor ("_Color", tempColor); //set transparency to start
	  
	  //repeat for other objects
	  openingText = openingTextObject.GetComponent<MeshRenderer>().material;
	  tempColor = openingText.color;
	  tempColor.a = 0;
	  openingText.SetColor ("_Color", tempColor);
	  
	  interactableEye = startingEye.GetComponent<SpriteRenderer>().material;
	  tempColor = interactableEye.color;
	  tempColor.a = 0;
	  interactableEye.SetColor ("_Color", tempColor);
	  startingEye.GetComponent<SphereCollider>().radius = 0.0f;
	  
	  instructions = instructionsObject.GetComponent<MeshRenderer>().material;
	  tempColor = instructions.color;
	  tempColor.a = 0;
	  instructions.SetColor ("_Color", tempColor);
	 
	}
	
	void Update () {
	
	  //if the plane isnt present yet
	  if (planeMaterial.color.a <= 1f && planeComplete == false) {
	  
	    FadeIn (planeMaterial, fadeSpeed); //starts by fading in the plane
	   
	  
	  }
	  
	  else if (planeComplete == false) {
	  
	    planeComplete = true; //sets flag to true, plane is fully faded in
	  
	  }
	  
	  //if the plane is fully faded in, start fading in opening text
	  if (planeComplete == true && textComplete == false && openingText.color.a <= 1) {
	  
	    FadeIn (openingText, fadeSpeed); //fades in opening text
	  
	  }
	  
	  //flags the opening text as fully faded in
	  else if (textComplete == false && openingText.color.a > 1) {
	  
	    textComplete = true;
	  
	  }
	  
	  //if the opening text is fully faded in, commence fading in the eye
	  if (textComplete == true && eyeComplete == false && interactableEye.color.a <= 1) {
	  
	    FadeIn (interactableEye, fadeSpeed); //fades in the eye
	  
	  }
	  
	  //flags the eye as fully faded in
	  else if (eyeComplete == false && interactableEye.color.a > 1) {
	  
	    eyeComplete = true;
	  
	  }
	  
	  //if everything else is faded in, fade in the instructions
	  if (eyeComplete == true && instructionsComplete == false && instructions.color.a <= 1) {
	  
	    FadeIn(instructions, fadeSpeed); //fades in the instructions
	  
	  }
	  
	  //if instructions are done, create the collider for raycast on the eye
	  else if (instructionsComplete == false && instructions.color.a > 1) {
	  
	    instructionsComplete = true;
	    startingEye.GetComponent<SphereCollider>().radius = 0.05f;
	  
	  }
	  
	  //if the gaze system detects the eye and is activated
	  if (commenceFadeOut) {
	  
	    if (planeMaterial.color.a > 0 ||
		      openingText.color.a > 0 ||
		      interactableEye.color.a > 0 ||
		      instructions.color.a > 0)
		  {
		  
		    //fades out everything
		    FadeOut(planeMaterial, fadeSpeed);
		    FadeOut(openingText, fadeSpeed);
		    FadeOut(interactableEye, fadeSpeed);
		    FadeOut(instructions, fadeSpeed);
		  
		  }
		  
		  //destroys them when they're done fading out
		  else {
		  
		    GameObject.Destroy (instructionsObject);
		    GameObject.Destroy (startingEye);
		    GameObject.Destroy (openingTextObject);
		    GameObject.Destroy (this.gameObject);
		    Application.LoadLevel (1); //load the first level
		  
		  }
		}
	}
	
	/* Fades in material at speed fadeSpeed */
	void FadeIn(Material material, float fadeSpeed) {
	
	  Color tempColor = material.color;
	  tempColor.a += fadeSpeed;
	  material.SetColor ("_Color", tempColor);
	
	}
	
	/* Fades out material at speed fadeSpeed */
	void FadeOut(Material material, float fadeSpeed) {
	
	  Color tempColor = material.color;
	  tempColor.a -= fadeSpeed;
	  material.SetColor ("_Color", tempColor);
	
	}
	
	/* Activated by the gaze system */
	public void CommenceFadeOut() {
	
	  commenceFadeOut = true;
	
	}
}
