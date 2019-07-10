using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour {

    Slider healthBar;
	// Use this for initialization
	void Start () {
        healthBar = this.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = GameManager.health;
	}
}
