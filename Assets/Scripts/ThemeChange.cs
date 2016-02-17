using UnityEngine;
using System.Collections;

/* This script allows the user to cycle through provided background
 * themes
 */
public class ThemeChange : MonoBehaviour {

  public static int skyboxIndex = 1; //next available skybox is the second one

  public Material[] skyboxes; //material array of skyboxes

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* Called by gaze system */
	void Activate() {
	
	  //changes the skybox on each one of the OVR eyes
	  AnchorScript.leftEyeAnchor.GetComponent<Skybox>().material = skyboxes[ThemeChange.skyboxIndex];
	  AnchorScript.rightEyeAnchor.GetComponent<Skybox>().material = skyboxes[ThemeChange.skyboxIndex];
	  
	  ThemeChange.skyboxIndex++; //increments the skybox index
	  
	  //loops the skyboxes to start from beginning again
	  if (ThemeChange.skyboxIndex == skyboxes.Length) {
	  
	    ThemeChange.skyboxIndex = 0;
	  
	  }
	}	
}
