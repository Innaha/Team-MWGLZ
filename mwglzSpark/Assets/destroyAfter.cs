using UnityEngine;
using System.Collections;

public class destroyAfter : MonoBehaviour {
	public float destroyTimer;
	float lifeTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer += Time.deltaTime;

		if (lifeTimer > destroyTimer) {
			Destroy(gameObject);
		}
	}
}
