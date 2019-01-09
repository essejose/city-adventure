using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public float velocidade ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0.0f, 0.0f);
        float mover_y = Input.GetAxisRaw("Vertical") * velocidade * Time.deltaTime;
        transform.Translate(0.0f, mover_y, 0.0f);
    }
}
