using UnityEngine;
using System.Collections;


/* Purpose: Creates static left eye and right eye variables
 * that can be accessed from any other script using
 * AnchorScript.leftEyeAnchor or AnchorScript.rightEyeAnchor
 */
public class AnchorScript : MonoBehaviour {

    public GameObject leftAnchor; //drag left eye anchor
    public GameObject rightAnchor; //drag right eye anchor
    
    public static GameObject leftEyeAnchor; //creates statics
    public static GameObject rightEyeAnchor;

	// Use this for initialization
	void Start () {
	
	//sets statics
	AnchorScript.leftEyeAnchor = leftAnchor;
	AnchorScript.rightEyeAnchor = rightAnchor;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
