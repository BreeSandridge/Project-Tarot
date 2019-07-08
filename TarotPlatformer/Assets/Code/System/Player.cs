using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 6f;
    public float jump_speed = 500f;
    public float run_speed = 5.5f;
    public float dash_distance = 1.5f;
    public int numJumps = 1;
    public float dash = 0.4f;
    public static float playerX;
    public float Rtele;
    public float Ltele;
    public float Dashcd = 5;
    public float jumpt;
    public bool activated = false;
    Rigidbody2D rb;
    Animator anim;
    Vector3 startingPosition; // If we die we will teleport player to starting position.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;
        Dashcd -= Time.deltaTime;

        /*if (Input.GetKey(KeyCode.[enter key name]))
        {
            movement = input * speed * run_speed;
        }*/

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (numJumps == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("MakeFall", true);
            jumpt = Time.time;
            activated = true;
            numJumps++;
        }

        if (activated)
        {
            if (Time.time - jumpt > 0.2)
            {
                rb.AddForce(new Vector3(0, jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
                activated = false;
            }
        }

        playerX = transform.position.x;

        if (Input.GetKey(KeyCode.LeftShift) && Dashcd <= 0 && input == 1)
        {
            RTeleport();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Dashcd <= 0 && input == -1)
        {
            LTeleport();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("MakeWalk", true);
        }

        else
        {
            anim.SetBool("MakeWalk", false);
        }
    }

    void RTeleport()
    {
        transform.position = new Vector3(transform.position.x + Rtele, transform.position.y, transform.position.z);
        Dashcd = 5;
    }

    void LTeleport()
    {
        transform.position = new Vector3(transform.position.x - Ltele, transform.position.y, transform.position.z);
        Dashcd = 5;
    }

    void OnCollisionEnter2D(Collision2D col) // col is the trigger object we collided with
    {
        /*example code 
        if (col.tag == "Coin")
        {
            Destroy(col.gameObject); // remove the coin
        }*/

        if(col.collider.tag == "Ground")
        {
            numJumps = 0;
            anim.SetBool("MakeFall", false);
        }
    }
}
