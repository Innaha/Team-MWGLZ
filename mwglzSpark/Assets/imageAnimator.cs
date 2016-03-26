using UnityEngine;
using System.Collections;

public class imageAnimator : MonoBehaviour {

	public Texture2D[] animImages;
	public float animSpeed;
	public bool animOn;
	Renderer thisRenderer;
	float animTimer;
	int currentAnimIndex;


	//SCIPT ONLY USED FOR STATE CHECKS. WILL BE REPLACED BY MONSTER ANIMS. 

	// Use this for initialization
	void Start () {
		thisRenderer = this.GetComponent<Renderer> ();
		thisRenderer.material.mainTexture = animImages [0];
		currentAnimIndex = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		animTimer += Time.deltaTime;
		animateThis ();

	}


	void animateThis(){
		if (animTimer >= animSpeed) {

			thisRenderer.material.mainTexture = animImages[currentAnimIndex];
			currentAnimIndex += 1;
			animTimer = 0;
			if(currentAnimIndex == animImages.Length){
				currentAnimIndex = 1;

			}
		}

	}

	void getTimer(int thisTime){
		//animSpeed = (float)thisTime / 10;
		if (thisTime == 1) {
			animSpeed = 0.6f;

		}
		if (thisTime == 2) {
			animSpeed = 0.4f;
			
		}
		if (thisTime == 3) {
			animSpeed = 0.3f;
			
		}

		if (thisTime == 4) {
			animSpeed = 0.1f;
			
		}

	}
}
