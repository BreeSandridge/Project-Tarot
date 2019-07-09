using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChariot : TarotCard {
    public bool current = false;
    public bool change = false;
    float time = 0f;
    public override void Ability()
    {
        current = !current;

        if (current)
        {
            GameManager.speed *= 2;
        }
        else
        {
            GameManager.speed /= 2;
        }

    }

    public override void Start()
    {
        
    }

    public override void Update() {

        if (GameManager.chariotAbility) {
            if (time == 0){
                time = Time.time;
                Ability();
            }

            if (Time.time - time > 10)
            {
                Ability();
                GameManager.chariotAbility = false;
            }



        }


    }


}
