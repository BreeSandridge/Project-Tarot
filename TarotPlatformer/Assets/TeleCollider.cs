using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCollider : MonoBehaviour {
    public int dist;
    int colls = 0;
	// Use this for initialization
	void Start () {
        

        GameManager.TpPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.dir) {
            transform.position = GameManager.playerPos += new Vector3(dist, 0, 0);
        } else {
            transform.position = GameManager.playerPos -= new Vector3(dist, 0, 0);
        }

        GameManager.TpPos = transform.position;

        if (colls > 0) {
            //gets parent's parent (the player) and accesses the player.cs file and callse the setTeleBool method
            // setTeleBool sets bool for dashing
            transform.parent.parent.GetComponent<Player>().setTeleBool(int.Parse(this.gameObject.name), false, this.transform.position);
        } else {
            colls = 0;
            transform.parent.parent.GetComponent<Player>().setTeleBool(int.Parse(this.gameObject.name), true, this.transform.position);
        }


        

    }

    void OnTriggerEnter2D(Collider2D coll) {
        colls++;
    }

    void OnTriggerExit2D(Collider2D coll) {
        colls--;
    }
}
