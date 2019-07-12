using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {


    // Use this for initialization
    void Start () {
      
        Destroy(this.gameObject, 2);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.health -= 5;
            Destroy(this.gameObject);
        }
    }

}
