using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMagician : TarotCard {

    public GameObject obj;
    public override void Ability() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Instantiate(obj, Player.transform.position, Quaternion.identity);
        }
    }


    // Use this for initialization
    public override void Start() {
        name = "The Magician";
    }

    // Update is called once per frame
    public override void Update() {
        
    }
}
