using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    private Vector3 start;

    private float lastMove;
    private float deltaTime;

    bool goingUp = true;

    public float moveSpeed = 0.05f; 

    // Use this for initialization
    void Start () {
        start = transform.position;
        lastMove = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        hover();
	}

    private void hover() {
        deltaTime = Time.time - lastMove;
        if (deltaTime > .1)
        {
            if (goingUp)
            {
                if (start.y + .5 >= transform.position.y)
                {
                    transform.position += new Vector3(0, moveSpeed, 0);
                }
                else
                {
                    goingUp = !goingUp;
                }
            }
            else
            {
                if (start.y < transform.position.y)
                {
                    transform.position += new Vector3(0, -moveSpeed, 0);
                }
                else
                {
                    goingUp = !goingUp;
                }
            }
            lastMove = Time.time;
        }
    }
}
