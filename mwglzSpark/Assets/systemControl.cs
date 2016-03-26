using UnityEngine;
using System.Collections;

public class systemControl : MonoBehaviour {

	// Use this for initialization
	//This script handles all the ingame elements. It also handles game time and tracks the game state.

	//General

	public float currentTime;
	Texture2D[] ingameAnimations;
	public bool gameOver;
	public bool gameOn;
	public GameObject mainCylinder;
	public Light cylinderLight;
	public bool[] beaconTracker;
	public GameObject gameOverScreen;
	public TextMesh gameOverText;
	bool allActive;
	int currentDarkLevel;
	int beaconsOff;


	//Gameobjects
	public GameObject[] objectBeacon; 

	void Awake(){
		gameOn = false;

	}

	void Start () {
		allActive = true;
		beaconTracker [0] = true;
		beaconTracker [1] = true;
		beaconTracker [2] = true;
		beaconTracker [3] = true;
		beaconTracker [4] = true;
		cylinderLight.intensity = 0;
		cylinderLight.spotAngle = 0;
		currentDarkLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		gameOverState ();
		if (gameOn) {
			currentTime += Time.deltaTime;
			if(beaconsOff == 5){
				gameOver = true;
				gameOn = false;
			}

			//DEBUG

			}
		if(Input.GetMouseButtonDown(1)){
			gameStateCheck();

		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			Application.LoadLevel(0);
		}
	}


	void addLight(string addSub){
		if (addSub == "+") {
			cylinderLight.intensity += 1;
			cylinderLight.spotAngle += 20;
			currentDarkLevel += 1;
		}
		if (addSub == "-" && currentDarkLevel > 0) {
			cylinderLight.intensity -= 1;
			cylinderLight.spotAngle -= 20;
			currentDarkLevel -= 1;
		}
		//Debug.Log (currentDarkLevel);
	}

	void gameOnOff(string onOff){
		if (onOff == "On") {
			gameOn = true;
		}
		if (onOff == "Off") {
			gameOn = false;
		}

	}

	void beaconStatusOn(int thisState){
		beaconTracker [thisState] = true;

	}

	void beaconStatusOff(int thisState){
		beaconTracker [thisState] = false;

	}

	void gameStateCheck(){
		for (int i = 0; i < beaconTracker.Length; i++) {
			if(beaconTracker[i] == true){
				Debug.Log(beaconTracker[i]);
				beaconsOff = 0;
				break;
			}
			if(beaconTracker[i] == false){
				Debug.Log (beaconTracker[i]);
				beaconsOff += 1;
				GameObject.FindWithTag("monster").SendMessage("getTimer", beaconsOff);
			}


		}

	}

	void gameOverState(){
		if (gameOver && !gameOn) {
			gameOverScreen.SendMessage("fadeInNooow");
			gameOverText.SendMessage("fadeInNooow");
		}

	}

	void setVignette(){


	}

}
