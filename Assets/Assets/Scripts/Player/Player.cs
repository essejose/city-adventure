using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public float velocidade ;
    Animator animator;
	public Text sensitive;

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
        float mover_x;
        float mover_y;
        if (Application.platform == RuntimePlatform.Android)
        {
            
            Debug.Log(Application.platform);
            mover_x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
            mover_y = CrossPlatformInputManager.GetAxisRaw("Vertical") * velocidade * Time.deltaTime;
        }
        else
        {
            mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
            mover_y = Input.GetAxisRaw("Vertical") * velocidade * Time.deltaTime;
			//Debug.Log(mover_x);
			//Debug.Log(mover_y);
        };


     
        transform.Translate(mover_x, 0.0f, 0.0f);
        transform.Translate(0.0f, mover_y, 0.0f);

		Debug.Log( mover_y );
		sensitive.text = mover_y.ToString();
		animator.SetFloat ("dirx", mover_x);
		animator.SetFloat("diry", mover_y);

        // animator.SetFloat("walk_top", Mathf.Abs(Input.GetAxisRaw("Vertical")));

//        if (mover_x > 0.0f) 
//
//        {
//            animator.SetInteger("dirx",2);
//        }
//        else if (mover_x < 0.0f)
//        {
//			animator.SetInteger("dirx",-2);
//        }
    }
}
