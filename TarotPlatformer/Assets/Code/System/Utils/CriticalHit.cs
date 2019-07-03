using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit {
    public static float damage = 10f;
    public bool active = false;
    public float critChance = 0.0f;
	

    
    public int critDamage(int baseAtk)
    {
        if (Random.RandomRange(0, 1) < GameManager.critChance)

        {
            return baseAtk * 2;
        }
        return baseAtk;
    }

}
