using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public int speed = 20;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        if (Player.dir == false) {
            speed *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(speed, 0, 0);
    }
}
