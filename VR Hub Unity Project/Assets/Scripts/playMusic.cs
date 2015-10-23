using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* We can't totally remember what this one does.
 * It was a long Hackathon. We didn't sleep much
 * Good luck
 */
public class playMusic : MonoBehaviour {

	private SongButtons buttonScript;
	
	private string musicName; //name of the music
	private Object musicFile; //actual music file

	// Use this for initialization
	void Start () {

		buttonScript = this.GetComponent<SongButtons> ();

        // loops for each available song to be played
		for (int i = 0; i < SongButtons.myMusic.Length; i++) { 

            //
			if (musicName.Equals (SongButtons.myMusic[i])) {
				musicFile = SongButtons.myMusic[i];
			}

		}

		GetComponent<AudioSource> ().clip = musicFile as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
