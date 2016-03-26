using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
	//This script handles the player states, life etc.
	public bool isMoving;
	AudioSource playerAudioSource;
	public AudioClip[] playerSounds;
	systemControl gameController;
	public GameObject thisPlayer;
	public GameObject playerFeet;
	public GameObject playerHands;
	public GameObject[] playerPrefabs;
	GameObject soundSource;
	Vector3 ponitClicked;
	public GameObject objectClicked;
	int flintAmount;
	private Transform playerPosition;
	public NavMeshAgent agent;
	public bool canLight;
	float cooldownTimer;
	float timeToCool;
	public Vector3 playerPos;
	public Vector3 lastPos;
	// Use this for initialization

	void Awake(){
		isMoving = false;

	}

	void Start () {
		gameController = GameObject.FindWithTag ("systemControl").GetComponent<systemControl> ();
		playerAudioSource = gameObject.GetComponent<AudioSource> ();
		agent = GetComponent<NavMeshAgent> ();
		soundSource = GameObject.FindWithTag ("soundControl");
		timeToCool = 2.1f;
		playerPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.gameOn) {
			clickMove ();
			clickInfo ();
			isMovingMisc();
			moveCheck();
			//mouseClickDown ();
		}
	}

	//MOVEMENT SKETCH.
	void clickMove(){
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
				if(hit.collider.tag == "isGround"){
					agent.destination = hit.point;

				}

				if(hit.collider.tag == "isClickable"){
					if(hit.collider.gameObject.GetComponent<beaconControl>().canLighted == false){
						agent.destination = hit.point;
					}
				}
			}
		}

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "beaconTrigger") {
			canLight = true;
			col.SendMessageUpwards("activateBeacon");

		}


	}

	void isMovingMisc(){
		if (isMoving) {
			playerFeet.GetComponent<ParticleSystem>().emissionRate = 3;

		}
		if (!isMoving) {
			playerFeet.GetComponent<ParticleSystem>().emissionRate = 0;

		}

	}



	void OnTriggerExit(Collider col){
		if (col.tag == "beaconTrigger") {
			canLight = false;
			col.SendMessageUpwards("deactivateBeacon");
		}

	}

	void clickInfo(){

		if (Input.GetMouseButton (0) && canLight) {
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(mouseRay, out hit, 100)){
				objectClicked = hit.collider.gameObject;
				if(objectClicked.tag == "isClickable"  && objectClicked.GetComponent<beaconControl>().canLighted){
					mouseClickDown();
				}
			}
			
		}
		//FIX
		if (objectClicked != null && objectClicked.tag == "isClickable") {
			if (Input.GetMouseButtonUp (0) && objectClicked.GetComponent<beaconControl> ().canLighted) {
				cooldownTimer = 0;
				Debug.Log ("SlappMusa");
			}
		
		}
	}

	void mouseClickDown(){

		if (Input.GetMouseButton (0)) {
			cooldownTimer += Time.deltaTime;
			if(cooldownTimer > timeToCool){
				Debug.Log (cooldownTimer);
				objectClicked.SendMessage("beaconOnDebug");
				cooldownTimer = 0;
			}
		}

	}

	void instantiateThis(){
		Instantiate (playerPrefabs [0], playerHands.transform.position, playerHands.transform.rotation);

	}


	void moveCheck(){
		playerPos = gameObject.transform.position;
		if (playerPos == lastPos) {
			//Debug.Log("Not moving");
			isMoving = false;
			if(!isMoving){


			}

				


		}
		//Fix gameOn animation jerk at start 
		if (playerPos != lastPos) {
			isMoving = true;
		}
		lastPos = playerPos;

	}

	void playPlayerSound(int thisSound){

			playerAudioSource.PlayOneShot(playerSounds[thisSound]);

	}


}
