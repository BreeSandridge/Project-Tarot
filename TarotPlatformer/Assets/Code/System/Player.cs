using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
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
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * GameManager.speed;
        GameManager.Dashcd -= Time.deltaTime;

        /*if (Input.GetKey(KeyCode.[enter key name]))
        {
            movement = input * speed * run_speed;
        }*/

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (GameManager.numJumps == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, GameManager.jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
            GameManager.numJumps++;
        }

        GameManager.playerX = transform.position.x;

        if (Input.GetKey(KeyCode.LeftShift) && GameManager.Dashcd <= 0 && input == 1)
        {
            RTeleport();
        }

        if (Input.GetKey(KeyCode.LeftShift) && GameManager.Dashcd <= 0 && input == -1)
        {
            LTeleport();
        }

        ability();
    }

    void RTeleport()
    {
        transform.position = new Vector3(transform.position.x + GameManager.Rtele, transform.position.y, transform.position.z);
        GameManager.Dashcd = 5;
    }

    void LTeleport()
    {
        transform.position = new Vector3(transform.position.x - GameManager.Ltele, transform.position.y, transform.position.z);
        GameManager.Dashcd = 5;
    }


    private static void ability() {
        TarotDeck.ability();
    }

    //movement code
    private void movement()
    {
        playerPos = transform.position;
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * GameManager.speed;

        if (input > 0)
        {
            dir = true;
        }
        else if (input < 0)
        {
            dir = false;
        }

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, GameManager.jump_speed, 0)); // Adds 100 force straight up, might need tweaking on that number
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

    void OnCollisionEnter2D(Collision2D col) // col is the trigger object we collided with
    {
        /*example code 
        if (col.tag == "Coin")
        {
            Destroy(col.gameObject); // remove the coin
        }*/

        if (col.collider.tag == "Ground")
        {
            GameManager.numJumps = 0;
        }
    }
}
