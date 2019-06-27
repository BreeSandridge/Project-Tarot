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
    //public Transform destination;
    Rigidbody2D rb;
    Vector3 startingPosition; // If we die we will teleport player to starting position.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement = input * speed * dash_distance;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = input * speed * run_speed;
        }


        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (numJumps == 0 && Input.GetKeyDown(KeyCode.Space))
        {
             rb.AddForce(new Vector3(0, jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
             numJumps++;
             Debug.Log("jumped!");
        }

        //if (Input.GetKey(KeyCode.LeftControl))
      //  {
            //new Vector2(transform.position.x + 0.4f, 0);
            //transform.position = destination.position;
       // }
    }


    void OnCollisionEnter2D(Collision2D col) // col is the trigger object we collided with
    {
        //example code 
       // if (col.tag == "Coin")
        //{
        //    Destroy(col.gameObject); // remove the coin
        //}

        if(col.collider.tag == "Ground")
        {
            numJumps--;
            Debug.Log("Landed");
        }
    }
}
