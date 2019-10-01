using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public GameObject enemyParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

 
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("enter");
		Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Weapon") { 
			--health;

			Destroy (col.gameObject);
			col.GetComponent<Sword> ().CreateParticle ();

			if (health <= 0) {
				Instantiate (enemyParticle, transform.position,transform.rotation);
				Destroy (gameObject);
		
			}
		}		
	}
}
