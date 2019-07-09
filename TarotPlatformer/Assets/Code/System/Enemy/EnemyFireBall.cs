using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour {

    public int speed = 20;
    float t;
    public  GameObject obj;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        t = Time.time;
        rb = GetComponent<Rigidbody2D>();

        if (PeytonEnemyAI.directionToPlayer == false)
        {
            speed = -20 ;
        }
        else
        {
            speed = Mathf.Abs(speed);
        }
        rb.velocity = new Vector3(speed, 0, 0);
        Destroy(gameObject, 3);
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        

        if (coll.gameObject.tag.Equals("Player")) {
            GameManager.health -= 10f;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag.Equals("Fireball")) {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /* rb.velocity = new Vector3(speed, 0, 0);
        if (Time.time - t < 6)
        {
            
        }*/
    }
}

