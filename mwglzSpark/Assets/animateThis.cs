using UnityEngine;
using System.Collections;

public class animateThis : MonoBehaviour {
	//Animation thisAnim;
	playerControl playerScript;
	systemControl systemScript;
	AudioSource playerAudio;
	public GameObject playerHands;
	Animation charAnims;
	// Use this for initialization

	void Start () {
		//gameObject.GetComponent<Animation>().Play("walk");
		playerScript = GameObject.FindWithTag ("Player").GetComponent<playerControl>();
		systemScript = GameObject.FindWithTag ("systemControl").GetComponent<systemControl> ();
		playerAudio = GameObject.FindWithTag ("Player").GetComponent<AudioSource> ();
		charAnims = gameObject.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButton (0)){
			if(playerScript.isMoving == true && systemScript.gameOn){
				charAnims.Play("run");
			}
		if (Input.GetMouseButton (0)) {
			if (playerScript.canLight == true) {
				charAnims.Play ("use");
				if(!charAnims.IsPlaying("use")){
					Debug.Log ("SUSUSUSU");
				}
			}
		}

		//}
		if (playerScript.isMoving == false && !Input.anyKey) {
			charAnims.CrossFade("idle");
			//charAnims.Play("idle");

		}

	}


	void playAnimSound(int soundNumber){
		playerScript.SendMessage ("playPlayerSound", soundNumber);
		playerScript.SendMessage ("instantiateThis");
	}

	void playAnimRunSound(){
		playerScript.SendMessage ("playPlayerSound", Random.Range(2,5));
		
	}
}
