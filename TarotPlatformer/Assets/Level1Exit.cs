using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Go to level 1 Castle");
        SceneManager.LoadScene("Level1Castle");
       /* if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1Castle");
        }*/
    }
}
