using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject BossFireball;
    public GameObject fireballGun;
    public float firstShotDelay;
    public float fireRate;

    string moveDirection = "up";
   void Start()
    {
        InvokeRepeating("Shoot", firstShotDelay, fireRate);
    }
    void Shoot()

    {
        Instantiate(BossFireball, fireballGun.transform.position, transform.rotation);
    }

    private void Update()
    {
        //does moveDirection == up?
        if(moveDirection == "up")
        {
            Transform.position.y += 90;


            //move y position up

            //has the boss reached the max y position?
            if ()
            {
                moveDirection = "down";
            }
        }

        transform.y()
    }
}