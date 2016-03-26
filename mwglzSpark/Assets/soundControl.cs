using UnityEngine;
using System.Collections;

public class soundControl : MonoBehaviour {

	//This script handles sound. 
	public AudioClip[] gameSounds;
	int randomizedSound;
	AudioSource thisSource;
	// Use this for initialization
	void Start () {
		thisSource = GetComponent<AudioSource> ();
		thisSource.PlayOneShot(gameSounds[2]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playThisSound(int soundIndex){
		thisSource.PlayOneShot (gameSounds [soundIndex]);

	}

	void randomSound(){


	}
}
