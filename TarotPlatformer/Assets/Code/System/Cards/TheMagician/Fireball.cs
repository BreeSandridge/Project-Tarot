using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int speed = 0;
    float t;




    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        t = Time.time;
        rb = GetComponent<Rigidbody2D>();

        if (GameManager.dir == false)
        {
            speed *= -1;
        }
        else
        {
            speed = Mathf.Abs(speed);
        }
        rb.velocity = new Vector3(speed, 0, 0);
        Destroy(gameObject, 3);

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        /*if (col.tag.Equals("Enemy"))
        {
            Destroy(this.gameObject);
        }*/
    }



    void Update()
    {
        
    }
}
