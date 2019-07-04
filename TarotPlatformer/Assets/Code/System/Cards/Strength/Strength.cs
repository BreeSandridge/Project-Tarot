using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Strength : TarotCard {
    public bool active = false;
    public bool lastframe = false;
    




    public override void Ability()
    {
      
            if (!lastframe && active)
            {
            GameManager.damage *= 1.35f;
            GameManager.atk_speed *= 1.35f;

            }
            else if (lastframe && !active)
            {
            GameManager.atk_speed = 10f;
            }
        

    }

    public override void Start()
    {
       
    }

    public override void Update()
    {

    }

   
	
}
