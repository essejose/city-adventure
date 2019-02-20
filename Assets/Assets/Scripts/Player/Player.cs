using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public float velocidade;
    Animator animator;
	public Image[] hearts;
	public int maxHelth;
	public Text Tmover_y;
	public Text Tmover_x;
	int currentHealth;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
		currentHealth = maxHelth;
		getHealth();
    }
	
	// Update is called once per frame
	void Update () {
        Movement(); 	
		getHealth(); 
	}

	void getHealth(){
		
		for (int i = 0; i <= hearts.Length - 1 ; i++) {
			
			hearts[i].gameObject.SetActive (false);
		}

		for (int i = 0; i <= currentHealth - 1 ; i++) {
			
			hearts[i].gameObject.SetActive (true);
		}
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
        };

		 animator.SetFloat ("diry", 0f);
		 animator.SetFloat ("dirx", 0f);

		if (mover_y > 0.007f)
		{
			Debug.Log("Moving Up");
			animator.SetFloat ("diry",mover_y);
		}

		else if (mover_y < -0.007f)
		{
			Debug.Log("Moving Down");
			animator.SetFloat ("diry", mover_y);

		}

		if (mover_x > 0.007f)
		{
			Debug.Log("Moving Right");
			animator.SetFloat ("dirx", mover_x);
		}

		else if (mover_x < -0.007f)
		{
			Debug.Log("Moving left");
			animator.SetFloat ("dirx", mover_x);
		}
     
        transform.Translate(mover_x, 0.0f, 0.0f);
        transform.Translate(0.0f, mover_y, 0.0f);

		Tmover_y.text = " move y: "+ mover_y.ToString();
		Tmover_x.text = " move x: "+mover_x.ToString();
	
    }
}
