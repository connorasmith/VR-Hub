using UnityEngine;
using System.Collections;

/* Activates the YouTube screen */
public class YouTubeActivate : MonoBehaviour {

	public Object youtubeObject; //the YouTube prefab
	private GameObject youtubeScreen; //active screen after creation
	
	private bool activated = false; //flag to check if created
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	/* Called by Gaze System */
	void Activate() {
		
		//if it hasn't already been created
		if (!activated) {
			
			//sets the initial values for creation
			Quaternion screenRotation = new Quaternion(0.0f, 0.7f, -0.7f, 0.0f);
			Vector3 screenLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
			youtubeScreen = (GameObject) GameObject.Instantiate (youtubeObject, screenLocation, screenRotation);
			
			//moves it again just to make sure?
			youtubeScreen.transform.position = new Vector3(0,0,7);
			
			activated = true; //screen has been created
			
		}
		
		//if a screen already exists, destroy it
		else {
			
			GameObject.Destroy (youtubeScreen);
			activated = false;
			
		}
	}
}
