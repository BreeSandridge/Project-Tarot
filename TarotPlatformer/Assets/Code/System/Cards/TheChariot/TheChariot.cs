using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChariot : TarotCard {
    public bool lastframe = false;
    public bool active = false; 
    public override void Ability()
    {
        if (!lastframe && active)
        {
            GameManager.speed *= 1.35f;
        }
        else if (lastframe && !active)
        {
            GameManager.speed /= 1.35f;
        }
    }

    public override void Start()
    {

        GameManager manager = gameObject.GetComponent<GameManager>();
        
    }

    public override void Update()
    {
        Ability();
    }


}
