using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject BossFireball;
    public GameObject fireballGun;
    public float firstShotDelay;
    public float fireRate;
    public float speed = 2;
  //  public GameObject swordGun;
    //public float swordDelay;
   // public float swordRate;
   // public float fall = 2;

    string moveDirection = "up";
    void Start()
    {
        InvokeRepeating("Shoot", firstShotDelay, fireRate);

        Debug.Log(transform.position.x);
    }
    void Shoot()

    {
        Instantiate(BossFireball, fireballGun.transform.position, transform.rotation);
    }

    private void Update()
    {

        //does moveDirection == up?
        if (moveDirection == "up")
        {
            //move y position up
            transform.Translate(0, 1 * speed * Time.deltaTime, 0);

            //has the boss reached the max y position?
            if (transform.position.y >= 7)
            {
                moveDirection = "down";
            }

        }

        if (moveDirection == "down")
        {
            transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            if (transform.position.y <= 1)
            {
                moveDirection = "up";
            }

        }
        if (GetComponent<BossManager>().health <= 0f)
        {
            Application.LoadLevel("VictoryScreen");
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            //Debug.Log("Health left: " + health);
            GetComponent<BossManager>().health -= 10.0f;
        }
    }


}