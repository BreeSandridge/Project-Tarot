using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("I Am HERE");
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (GameManager.playerX >= 37)
        {
            Application.LoadLevel("VictoryScreen");
        }

    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Mve to next level");
    }

}
