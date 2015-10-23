using UnityEngine;
using System.Collections;

/* Creates the music player */
public class MusicActivate : MonoBehaviour {

    public Object musicPlayer; //the musicPlayer prefab
    private GameObject activeMusicPlayer; //stores player after creation
    
	private bool activated = false; //bool flag to check if already created

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* Called by gaze system */
	void Activate() {
	
	  //if not already activated
	  if (!activated) {
	 
	      //sets desired rotation for the music player
		  Quaternion tempQuat = new Quaternion(0.5f, 0.5f, -0.5f, -0.5f);
		
		  //creates the music player
		  activeMusicPlayer = (GameObject)GameObject.Instantiate (musicPlayer, transform.position, tempQuat);
		  
		  //sets the rotation and position
		  activeMusicPlayer.transform.rotation = tempQuat;
		  activeMusicPlayer.transform.position = new Vector3(0,0,10);
		  
		  activated = true; 
		  
	  }
	  
	  //destroys the music player if it was already active
	  else {
	  
	    GameObject.Destroy (activeMusicPlayer);
	  
	    activated = false;
	  
	  }
	}
}
