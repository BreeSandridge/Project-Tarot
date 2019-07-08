using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerexanple : MonoBehaviour {
    float t = Time.time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - t > 6)
        {
            //DO SOMETHING
        }
	}
}
