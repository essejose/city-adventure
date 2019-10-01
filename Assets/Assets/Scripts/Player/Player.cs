using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public float velocidade;
    Animator animator;
	public Image[] hearts;
	public int maxHealth;
	public Text Tmover_y;
	public Text Tmover_x;
	public int weaponThrust; 
	int currentHealth;
	float mover_x;
	float mover_y;
	string lastPosition = "Left";
	public GameObject weapon;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
		currentHealth = maxHealth;
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

	public void Attack(){
 		
	
 
		GameObject newWeapon = Instantiate (weapon, transform.position , weapon.transform.rotation);

	
		if (lastPosition == "Up")
		{
			newWeapon.transform.Rotate (0, 0, 0); 
			newWeapon.GetComponent<Rigidbody2D>().AddForce(Vector2.up * weaponThrust);
		}

		else 	if (lastPosition == "Down")
		{
			 
			newWeapon.transform.Rotate (0, 0, 180);
			newWeapon.GetComponent<Rigidbody2D>().AddForce(Vector2.down * weaponThrust);
		}

		if (lastPosition == "Right")
		{
			newWeapon.transform.Rotate (0, 0, -90);
			newWeapon.GetComponent<Rigidbody2D>().AddForce(Vector2.right * weaponThrust);
		}

		if (lastPosition == "Left")
		{
			newWeapon.transform.Rotate (0, 0, 90);
			newWeapon.GetComponent<Rigidbody2D>().AddForce(Vector2.left * weaponThrust);
		}



	}

    void Movement()
    {
       

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
			lastPosition = "Up";
			animator.SetFloat ("diry",mover_y);

		}

		else if (mover_y < -0.007f)
		{
			Debug.Log("Moving Down");
			lastPosition = "Down";
			animator.SetFloat ("diry", mover_y);


		}

		if (mover_x > 0.007f)
		{
			Debug.Log("Moving Right");
			lastPosition = "Right";
			animator.SetFloat ("dirx", mover_x);
	
		}

		else if (mover_x < -0.007f)
		{
			Debug.Log("Moving left");
			lastPosition = "Left";
			animator.SetFloat ("dirx", mover_x);

		}
     
        transform.Translate(mover_x, 0.0f, 0.0f);
        transform.Translate(0.0f, mover_y, 0.0f);

		Tmover_y.text = " move y: "+ mover_y.ToString();
		Tmover_x.text = " move x: "+mover_x.ToString();
	
    }
}
