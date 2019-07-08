using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour {

    public int speed = 20;
    float t;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        t = Time.time;
        rb = GetComponent<Rigidbody2D>();

        if (EnemyAI.dir == true)
        {
            speed *= -1;
        }
        else
        {
            speed = Mathf.Abs(speed);
        }
        rb.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector3(speed, 0, 0);
        if (Time.time - t < 6)
        {
            GameObject.Destroy(this);
        }
    }
}

