using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager{
    public static GameObject player;

    public static float speed = 6f;
    public static float jump_speed = 1100f;
    //public static float jump_speed = 500f;
    public static float health = 30f;
    public static float damage = 10f;
    public static float atk_speed = 11f;
    public static float critChance = .2f;
    public static float run_speed = 5.5f;
    public static float dash_distance = 1.5f;
    public static int numJumps = 1;
    public static float dash = 0.4f;
    public static float playerX;
    public static float Rtele = 4;
    public static float Ltele = 4;
    public static float Dashcd = 4;


    public static float EnemyDmg = 10f;

    public static bool dir = true;
    public static Vector3 playerPos = new Vector3(0, 0, 0);

    public static int newCards = 0;

    public static bool magicianAbility = false;
    public static bool chariotAbility = false;

    public static bool Activated = true;



    public static bool fall = false;
    public static bool jump = false;
    public static bool fbAtk = false;
    public static bool walk = false;
}
