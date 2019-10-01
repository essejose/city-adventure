using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float timer = .5f;
	public GameObject swordParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Instantiate (swordParticle, transform.position,transform.rotation);
			Destroy (gameObject);
		}

	}
	public void CreateParticle(){
		Instantiate (swordParticle, transform.position,transform.rotation);
	}
}
