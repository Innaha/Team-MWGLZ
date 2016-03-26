using UnityEngine;
using System.Collections;

public class beaconControl : MonoBehaviour {
	//This script tracks the state of the individual beacons; on, off, time to live etc. 


	// Use this for initialization

	public float timeLive;
	public float beaconTimer;
	private bool beaconOn;
	public bool canLighted;
	private GameObject thisBeacon;
	GameObject systemSource;
	private Collider thisCollider;
	public GameObject beaconParticles;
	public Light thisLight;
	float lightChangeRate;
	float lightTimer;
	GameObject soundSource;
	int beaconNumber;
	//Debug
	public Material[] beaconMats;

	void Start () {
		thisBeacon = this.gameObject;
		beaconNumber = int.Parse(thisBeacon.name [7].ToString ());
		beaconOn = true;
		lightChangeRate = 0.4f;
		soundSource = GameObject.FindWithTag ("soundControl");
		systemSource = GameObject.FindWithTag ("systemControl");

		//Debug
		timeLive = 8 + beaconNumber;
		gameObject.GetComponent<Renderer> ().material = beaconMats [0];
	}
	
	// Update is called once per frame
	void Update () {

		beaconDebugger ();
		beaconBurner ();
		bugTest ();
		//changeLight ();
	}


	
	//Sends a message to the systemController when timeLive reaches zero. Also destroys beaconParticles.
	void beaconOff(){
		beaconOn = false;


	}

	//Set new time to live on beacons. 
	void beaconBlaze(float liveTime){
		beaconTimer = 0;
		beaconParticles.GetComponent<ParticleSystem>().emissionRate = 10;
		timeLive = liveTime;



	}

	void beaconBurner(){
		if (timeLive > 0) {
			timeLive -= Time.deltaTime;
			thisLight.spotAngle = Random.Range (20,35);
		}

	}

	void changeLight(){
		lightTimer += Time.deltaTime;

		if (lightTimer > lightChangeRate) {
			thisLight.spotAngle = Random.Range (20,30);
			lightTimer = 0;
		}

	}

	void beaconDebugger(){
		//timeLive = Random.Range (0, 6);
		if (timeLive < 0 && beaconOn) {
			Debug.Log (thisBeacon.name + " Timeout");
			soundSource.SendMessage ("playThisSound", 4);
			gameObject.GetComponent<Renderer> ().material = beaconMats [1];
			beaconParticles.GetComponent<ParticleSystem>().emissionRate = 0;
			thisLight.spotAngle = 0;
			GameObject.FindWithTag("systemControl").SendMessage("addLight", "+");
			systemSource.SendMessage("beaconStatusOff", beaconNumber);
			systemSource.SendMessage("gameStateCheck");
			Camera.main.SendMessage ("addVignette", "+");
			Camera.main.SendMessage("Shake");
			beaconOn = false;

		}

	}

	void beaconOnDebug(){
		beaconOn = true;
		systemSource.SendMessage("beaconStatusOn", beaconNumber);
		Debug.Log (thisBeacon.name[7]);
		soundSource.SendMessage ("playThisSound", 3);
		//timeLive = Random.Range (3, 12);
		timeLive = 7 + beaconNumber;
		thisLight.spotAngle = Random.Range (20,30);
		beaconParticles.GetComponent<ParticleSystem>().emissionRate = 10;
		gameObject.GetComponent<Renderer> ().material = beaconMats [0];
		GameObject.FindWithTag ("systemControl").SendMessage ("addLight", "-");
		Camera.main.SendMessage ("addVignette", "-");
	}

	void thisBeaconOff(){



	}

	void activateBeacon(){
		canLighted = true;

	}

	void deactivateBeacon(){
		canLighted = false;
	}

	void bugTest(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			timeLive = 9999999;


		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			timeLive = 8 + beaconNumber;

		}
	}



}
