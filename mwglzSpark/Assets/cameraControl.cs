using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	//This scripts handles the camera and rays.

	// Use this for initialization

	Transform thisPosition;
	Vector3 clickPoint;
	Transform originPos;
	Transform travelPos;
	//public  vignetteScript;

	void Start () {
		//vignetteScript = FindObjectOfType<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration> ();
	}
	
	// Update is called once per frame
	void Update () {

	}




	void cameraShake(){




	}

	void addVignette(string thisValue){
		if (thisValue == "-") {
			FindObjectOfType<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration> ().intensity -= 0.03f;;

		}
		if (thisValue == "+") {
			FindObjectOfType<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration> ().intensity += 0.03f;

		}

	}
}
