using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("This script works!");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.playerX >= 37)
        {
            Debug.Log("Move to next level!");
            //Application.LoadLevel("VictoryScreen");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("MOve to next level");
        if (col.tag == "Player")
        {
            Application.LoadLevel("BossRoom");
        }

    }
}
