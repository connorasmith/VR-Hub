using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SongButtons : MonoBehaviour {

	public static Object[] myMusic; //will contain the music imported from folder
	private bool empty = false; //check if there is no music

	public const int songCount = 5; //total number of songs 
	public GameObject[] songArray = new GameObject[songCount]; //buttons array

	// Use this for initialization
	void Start () {

	
		//imports all audio clips in Resources/Music to objects array
		SongButtons.myMusic = Resources.LoadAll("Music",typeof(AudioClip));
		
		for (int i = 0; i < songCount; i++) {
			
			songArray[i].GetComponent<buttonScript>().buttonAudio = (AudioClip)SongButtons.myMusic[i];
			
		}

		//checks if no music
		if (SongButtons.myMusic.Length == 0) { 
			empty = true;
		}

		//if no music, then turn remaining buttons to stated text 
		if (empty) {
			songArray [0].GetComponent<buttonScript> ().buttonText.GetComponent<Text> ().text = 
				"No Music Available";
		//get the text of the button and set it to the name of the upcoming song
		} else {
			for (int i = 0; i < songArray.Length; i++) { 
				songArray [i].GetComponent<buttonScript> ().buttonText.GetComponent<Text> ().text = 
					SongButtons.myMusic[i].name;
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject[] getArray() {

		return songArray; 

	}
}
