using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
public int speed = 0;
    float t;

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        t = Time.time;
        rb = GetComponent<Rigidbody2D>();

        if (Player.dir == false) {
            //speed *= 0;
        } else {
            speed = Mathf.Abs(speed);
        }
        rb.velocity = new Vector3(speed, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
       // rb.velocity = new Vector3(speed, 0, 0);
        if (Time.time - t < 6)
        {
            GameObject.Destroy(this);
        }
                 
    }
}
