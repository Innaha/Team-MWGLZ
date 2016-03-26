using UnityEngine;
using System.Collections;

public class transparentFade : MonoBehaviour {
	public float fadeTime;
	public float fadeSpeed;
	public bool isDestructable;
	public bool systemMessager;
	public bool fadeIn;
	public bool fadeOut;
	public bool fadeInNow;
	GameObject systemController;
	float fadeCounter;
	Color thisMaterial;

	// Use this for initialization
	void Start () {
		thisMaterial = gameObject.GetComponent<Renderer>().material.color;
		systemController = GameObject.FindWithTag ("systemControl");
		fadeInNow = false;
		if (fadeIn) {
			thisMaterial.a = 0;
			gameObject.GetComponent<Renderer>().material.color = thisMaterial;

		}
	}
	
	// Update is called once per frame
	void Update () {

		if (fadeIn && fadeInNow) {
			fadeCounter += Time.deltaTime;
			fadeInDo ();
		}
		if (fadeOut) {
			fadeCounter += Time.deltaTime;
			fadeOutDo();
		}
	}

	void fadeOutDo(){
		if (fadeTime > fadeCounter) {
			thisMaterial.a -= fadeSpeed;
			gameObject.GetComponent<Renderer>().material.color = thisMaterial;
			if(thisMaterial.a <= 0 && isDestructable){
				if(systemMessager){
					systemController.SendMessage("gameOnOff", "On");

				}
				Destroy(gameObject);

			}
		}

	}

	void fadeInDo(){
		if (fadeTime > fadeCounter) {
			thisMaterial.a += fadeSpeed;
			gameObject.GetComponent<Renderer>().material.color = thisMaterial;
			if(thisMaterial.a >= 1 && isDestructable){
				if(systemMessager){
					systemController.SendMessage("gameOnOff", "On");
					
				}
				 
				//Destroy(gameObject);
				
			}
		}
		
	}
	void fadeInNooow(){
		fadeInNow = true;

	}
}
