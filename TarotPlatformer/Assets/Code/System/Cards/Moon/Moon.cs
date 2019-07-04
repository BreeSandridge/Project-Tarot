using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : TarotCard {
    public bool active = false;
    public bool lastframe = false;


    public override void Ability()
    {
        GameManager.health = vampirism(GameManager.health);
    }

    public override void Start()
    {
      
    }

    public override void Update()
    {
        
    }

    public float vampirism(float health)
    {
        if (Random.RandomRange(0, 1) > GameManager.critChance) {
            return health * 1.05f;
        }
        return health;
    }


}
