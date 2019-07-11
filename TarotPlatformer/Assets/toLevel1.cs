using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) // col is the trigger object we collided with
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1Castle");
        }
        
    }
}
