using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 3f;
    public float jump_speed = 500f;
    Rigidbody2D rb;
    Vector3 startingPosition; // If we die we will teleport player to starting position.
    public static bool dir = true;
    public static Vector3 playerPos = new Vector3(0, 0, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
    }

    void Update()
    {
        playerPos = transform.position;
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;

        if(input > 0) {
            dir = true;
        } else if(input < 0) {
            dir = false;
        }

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
        }
    }


    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {
        //example code 
        if (col.tag == "Coin")
        {
            Destroy(col.gameObject); // remove the coin
        }
    }
}
