using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager{
    public static GameObject player;

    public static float speed = 7f;
    public static float jump_speed = 1400f;
    //public static float jump_speed = 500f;
    public static float health = 100;
    public static float damage = 10f;
    public static float atk_speed = 10f;
    public static float critChance = .2f;

    public static float run_speed = 5.5f;
    public static float dash_distance = 1.5f;
    public static int numJumps = 1;
    public static float dash = 0.4f;
    public static float playerX;
    public static float Rtele;
    public static float Ltele;
    public static float Dashcd = 5;

    public static bool dir = true;
    public static Vector3 playerPos = new Vector3(0, 0, 0);

    public static int newCards = 0;

    public static bool magicianAbility = false;
    public static bool chariotAbility = false;

    public static bool Activated = true;

}
