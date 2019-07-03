using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : TarotCard {
    public bool active = false;
    public bool lastframe = false;

    public override void Ability()
    {
        if (!lastframe && active)
        {
            GameManager.critChance *= 1.5f;
        }
        else if (lastframe && !active)
        {
            GameManager.critChance /= 1.5f;
        }
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

    
}
