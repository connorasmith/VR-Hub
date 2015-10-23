using UnityEngine;
using System.Collections;

/* Plays music if the user looks at a music button */
public class gazeMusic : MonoBehaviour {

    public buttonScript parentButton;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* Activates the play music script on the button */
	void Activate() {
	
	  parentButton.GetComponent<buttonScript>().playMusic();
	
	} 
}
