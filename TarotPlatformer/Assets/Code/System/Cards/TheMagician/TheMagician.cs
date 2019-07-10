using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMagician : TarotCard {
    public GameObject obj;
    Vector3 pos;

    public override void Ability() {

        if (GameManager.magicianAbility) {
            Debug.Log(GameManager.dir);
            pos = GameManager.playerPos;

            if (GameManager.dir == true)
            {
                pos += new Vector3(1, 0, 0);
            }
            else
            {
                pos += new Vector3(-1, 0, 0);
            }
            

            Instantiate(obj, pos, Quaternion.identity);

            GameManager.magicianAbility = false;
            GameManager.fbAtk = true;
        }
    }


    // Use this for initialization
    public override void Start() {

        name = "The Magician";
    }

    // Update is called once per frame
    public override void Update() {
        Ability();
    }
}
