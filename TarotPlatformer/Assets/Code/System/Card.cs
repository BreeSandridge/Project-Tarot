using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    private Vector3 start;
    private float lastMove;

    // Use this for initialization
    void Start () {
        start = transform.position;
        lastMove = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = lastMove - Time.time;

        if (deltaTime > .1) {
            transform.position += new Vector3(0, 1, 0);
            lastMove = Time.time;
        }
	}
}
