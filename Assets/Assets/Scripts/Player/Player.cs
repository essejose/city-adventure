using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {


    public float velocidade ;
    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        Debug.Log(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        Debug.Log(CrossPlatformInputManager.GetAxisRaw("Vertical"));
        float mover_x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0.0f, 0.0f);
        float mover_y = CrossPlatformInputManager.GetAxisRaw("Vertical") * velocidade * Time.deltaTime;
        transform.Translate(0.0f, mover_y, 0.0f);



        // animator.SetFloat("walk_top", Mathf.Abs(Input.GetAxisRaw("Vertical")));

        if (mover_x > 0.0f) 

        {
            animator.SetInteger("dir",1);
        }
        else if (mover_x < 0.0f)
        {

        }
    }
}
