using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float t;
    public GameObject fireball;
    public GameObject player;
    public int counter;
    Vector3 pos;
    Rigidbody2D rb2D;
    SpriteRenderer sr;
    Vector3 size;
    public static bool dir;
    public Transform leftGun;
    public Transform rightGun;
   


    private void Start()
    {
    }

    private void Update()
    {
        pos = transform.position;
        Vector3 pPos = player.transform.position;
        float len = (pos - pPos).magnitude;
        //enemy is right of player 
        if (pos.x > pPos.x)
        {
            dir = true; ;
            //Debug.Log("Left Player");
        }
        else
        //enemy is left of player
        {
            dir = false;
            // Debug.Log("Right Player");
        }

        if (len < 8)
        {
            if (Time.time - t > 2)
            {
                //Enemy - Player
                if (dir)
                {
                    Instantiate(fireball, leftGun.position, Quaternion.identity);
                    t = Time.time;
                    Debug.Log("Found You, Lefty");
                }
                //Player - Enemy
                else
                {
                    Instantiate(fireball, rightGun.position, Quaternion.identity);
                    t = Time.time;
                    Debug.Log("Found You, Righty");
                }
                t = Time.time;
            }
        }

        

    }
    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {

        if (col.tag == "Fireball")
        {
            Destroy(col.gameObject);
            EnemyManager.health -= 10f;
        }



        //private void Start()
        {
            t = Time.time;
            sr = GetComponent<SpriteRenderer>();
            size = new Vector3(sr.bounds.size.x - 2, 0, 0);
            //size = new Vector3(5, 0, 0);
            dir = false;
        }
    }
}