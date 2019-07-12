using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 6f;
    public float jump_speed = 500f;
    public float run_speed = 5.5f;
    public float jumpt; //These variables helped keep track of timers within animations.
    public float Healt;
    public float Dasht;
    public bool jumpActivation = false; //Bools used for the animation below.
    public bool healActivation = false;
    public bool dashActivationR = false;
    public bool dashActivationL = false;
    Rigidbody2D rb;
    Animator anim; //The objects below helped in coding for animation, simple in concept, but hard to learn for the first time.
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim41;
    Vector3 startingPosition; // If we die we will teleport player to starting position.
    public GameObject teleCard;
    // If we die we will teleport player to starting position.
    //public static bool dir = true;

    private bool t1 = false;
    private bool t2 = false;
    private bool t3 = false;
    private bool t4 = false;
    private bool t5 = false;
    private Vector3[] teleLocat = new Vector3[5];
    private int tIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
        GameManager.playerPos = startingPosition;
        //GameManager.player = this.gameObject;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        GameManager.playerPos = transform.position;
        //GameManager.playerPos = transform.GetChild(0).position;

        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * /*GameManager.*/speed;
        GameManager.Dashcd -= Time.deltaTime; //This keeps track of how often the player can dash.

        if (input > 0)
        {
            GameManager.dir = true;
        }
        else if (input < 0)
        {
            GameManager.dir = false;
        }


        if (GameManager.Activated)
        {
            /*if (Input.GetKey(KeyCode.[enter key name]))
            {
                movement = input * speed * run_speed;
            }*/

            rb.velocity = new Vector3(movement, rb.velocity.y, 0);


            if (GameManager.numJumps == 0 && Input.GetKeyDown(KeyCode.W)) //This method checks to make sure the player can't double jump and then starts an animation and sets a timer for another.
            {
                anim.SetBool("MakeFall", true);//animation set
                jumpt = Time.time; //timer set
                jumpActivation = true;
                GameManager.numJumps++;

                GameManager.jump = true;
            }

            if (jumpActivation)//code caried out by the activation of the bool above.
            {

                if (Time.time - jumpt > 0.1)
                {
                    rb.AddForce(new Vector3(0, jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
                    jumpActivation = false;
                }
            }


            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("MakeWalk", true);
                GameManager.walk = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("MakeWalkF", true);
                GameManager.walk = true;
            }

            else
            {
                anim.SetBool("MakeWalkF", false);
                GameManager.walk = false;
            }
        

            /*
             * if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("Heal0", true);
                anim2.SetBool("Heal1", true);
                Healt = Time.time;
                healActivation = true;
            }

            if (healActivation)
            {
                if (Time.time - Healt > 1)
                {
                    anim.SetBool("Heal0", false);
                    anim2.SetBool("Heal1", false);
                    healActivation = false;
                }
            }

            if (Input.GetKey(KeyCode.K))
            {
                anim.SetBool("Dead", true);
            }

            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetBool("Dead", false);
            }
            */

            if (GameManager.health <= 0)//Displays death anim if player health == 0;
            {
                anim.SetBool("Dead", true);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && GameManager.Dashcd <= 0 && GameManager.dir)//Code for the dash @param leftshift, dash is not on cooldown, which direction player is walking
        {
            chooseTLocat();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            rb.gravityScale = 0f;// sets grav to 0 to temporarily hold the player in place
            GameManager.Activated = false;
            anim3.SetBool("DAB0", true);// starts anim
            Dasht = Time.time;
            dashActivationR = true;
            //Instantiate(teleCard, transform.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.LeftShift) && GameManager.Dashcd <= 0 && !GameManager.dir)//Same as the cod above except for if the player is facing left
        {
            chooseTLocat();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            rb.gravityScale = 0f;
            GameManager.Activated = false;
            anim3.SetBool("DAB0", true);
            Dasht = Time.time;
            dashActivationL = true;
            //Instantiate(teleCard, transform.position, transform.rotation);
        }

        if (dashActivationR)//player anims for right dash, redirects to RTeleport
        {
            if (Time.time - Dasht > 0.4)
            {
                anim3.SetBool("DAB0", false);
                anim.SetBool("VisiblePlayer", false);
                anim4.SetBool("DAB1R", true);
            }

            if (Time.time - Dasht > 0.8)
            {
                anim4.SetBool("DAB1R", false);
                dashActivationR = false;
                RTeleport();
            }
        }

        if (dashActivationL)//player anims for left dash, redirects to LTeleport
        {
            if (Time.time - Dasht > 0.4)
            {
                anim3.SetBool("DAB0", false);
                anim.SetBool("VisiblePlayer", false);
                anim41.SetBool("DAB1L", true);
            }

            if (Time.time - Dasht > 0.8)
            {
                anim41.SetBool("DAB1L", false);
                dashActivationL = false;
                LTeleport();
            }
        } 

        ability();

        Debug.Log(GameManager.health);
        if (GameManager.health <= 0f)
        {
            Application.LoadLevel("Game_Over");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(teleLocat[0].x, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = new Vector3(teleLocat[1].x, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = new Vector3(teleLocat[2].x, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = new Vector3(teleLocat[3].x, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = new Vector3(teleLocat[1].x, transform.position.y, transform.position.z);

        }
    }

    void RTeleport()//Teleports player right upon activation of the anims
    {
        transform.position = new Vector3(teleLocat[tIndex].x, transform.position.y, transform.position.z);
        anim.SetBool("VisiblePlayer", true);
        rb.gravityScale = 6f;
        GameManager.Dashcd = 4;
        GameManager.Activated = true;
    }

    void LTeleport()//Teleports player left upon activation of the anims
    {
        transform.position = new Vector3(teleLocat[tIndex].x, transform.position.y, transform.position.z);
        anim.SetBool("VisiblePlayer", true);
        rb.gravityScale = 6f;
        GameManager.Dashcd = 4;
        GameManager.Activated = true;
    }

    private void chooseTLocat()
    {
        Debug.Log("T1:" + t1);
        Debug.Log("T2:" + t2);
        Debug.Log("T3:" + t3);
        Debug.Log("T4:" + t4);
        Debug.Log("T5:" + t5);
        if (t1)
        {
            tIndex = 0;
        }
        if (t2) {
            tIndex = 1;
        }
        if (t3)
        {
            tIndex = 2;
        }
        if (t4)
        {
            tIndex = 3;
        }
        if (t5)
        {
            tIndex = 4;
        }
    }

    void resetTeleBool() {
        t1 = false;
        t2 = false;
        t3 = false;
        t4 = false;
        t5 = false;
    }

    public void setTeleBool(int num, bool state, Vector3 Pos) {
        if (num == 1) {
            t1 = state;
            teleLocat[0] = Pos;
        } else if (num == 2) {
            t2 = state;
            teleLocat[1] = Pos;
        } else if (num == 3) {
            t3 = state;
            teleLocat[2] = Pos;
        } else if (num == 4) {
            t4 = state;
            teleLocat[3] = Pos;
        } else if (num == 5) {
            t5 = state;
            teleLocat[4] = Pos;
        }
    }


    private static void ability() {
        TarotDeck.ability();
    }

  
    
    void OnCollisionEnter2D(Collision2D col) // col is the trigger object we collided with
    {        
        if (col.gameObject.tag == "Ground")
        {
            GameManager.numJumps = 0;
            anim.SetBool("MakeFall", false);
            // remove the coin
        } else if (col.gameObject.tag == "Coin")
        {
            print("this");
            Destroy(col.gameObject);
        }


    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            GameManager.numJumps = 1;
        }
    }
}
