using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_ToPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("Main_Menu");
            GameManager.health = 100f;
        }
        
    }

}
