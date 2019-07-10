using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeytonEnemyAI : MonoBehaviour {

    public float speed = 3f;
    public float jump_speed = 500f;
    public float health = 100f;
    public float damage = 10f;
    public float atk_speed = 10f;
    Animator anim;

    float Dtimer = 0f;

    public enum State {
        Walk,
        Attack,
        Die
    }

    public bool dir = true;

    public static bool directionToPlayer;
    bool isPlayerInSightRange;
    float distanceToPlayer;

    bool visible = true;
    bool playerFound;
    int i;
    float t = 0;

    public GameObject weapon;

    Rigidbody2D rb;
    public State state;

    Collider2D playerCol;

    int layerMask;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        state = State.Walk;
        anim = gameObject.GetComponent<Animator>();
        isPlayerInSightRange = false;

    }


    void Update() {
        //DrawBounds();
        if (state == State.Walk) {
            anim.SetBool("MageWalk", true);
            walk();
            lookForObstacles();
        } else if (state == State.Attack) {
            anim.SetBool("MageWalk", false);
            attack();
            lookForObstacles();
        }
        else if (state == State.Die)
        {
            anim.SetBool("MageWalk", false);
            anim.SetBool("MageDead", true);
            if (Time.time - Dtimer > 1) {
                Destroy(gameObject);
            }
            /**
            /**
             * Todo: create die method
             **/
        }

        if (health <= 0f)
        {
            if (state != State.Die)
            {
                Dtimer = Time.time;
                state = State.Die;
            }

        }
    }

    private void die()
    {

    }

    private void lookForObstacles()
    {
        i = 0;
        playerFound = false;
        visible = false;

        // Code for visibility detection
        if (isPlayerInSightRange) {
            var heading = GameManager.playerPos - this.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            if (direction.x > 0) {
                directionToPlayer = true;
            } else if (direction.x < 0) {
                directionToPlayer = false;
            }

            RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, direction, distance);

            while (i < hits.Length && !playerFound && !visible)
            {

                if (!hits[i].collider.gameObject.CompareTag("Enemy"))
                {
                    if (hits[i].collider.gameObject.CompareTag("Player"))
                    {
                        playerFound = true;
                        visible = true;
//                        Debug.Log("Player Found");
                    }
                    else
                    {
  //                      Debug.Log("thing it sees: " + hits[i].collider.gameObject.name);
                        visible = false;
                    }
                }
                i++;
            }

        }
        if (visible)
        {
            //Debug.Log("Can See Player");
            state = State.Attack;
        }
        else
        {
            //Debug.Log("Cannot See Player");
            state = State.Walk;
        }
    }

    private void attack()
    {
        if (Time.time - t > 2)
        {
            //Enemy - Player
            if (directionToPlayer)
            {
                Instantiate(weapon, transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                GameManager.fbAtk = false;
                t = Time.time;
                Debug.Log("Found You, Lefty");
            }
            //Player - Enemy
            else
            {
                Instantiate(weapon, transform.position - new Vector3(1f, 0f, 0f), Quaternion.identity);
                t = Time.time;
                Debug.Log("Found You, Righty");
            }
            t = Time.time;
        }
    }

    private void walk() {
        if (dir)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        }
    }

    //checks tos see if player is in sight range
    void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Player")
        {
            isPlayerInSightRange = true;
            
        }

    }

    //tells when player is no longer in sight
    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            isPlayerInSightRange = false;
            
        }
    }

    public void CollisionDetected(ChildCollider childScript)
    {
        print("child collided: " + childScript.name);


        if (childScript.name == "Right" && childScript.name != "Left") {
            dir = false;
        } else if (childScript.name != "Right" && childScript.name == "Left") {
            dir = true;
        } else if (childScript.name == "Right" && childScript.name == "Left")
        {
            Debug.Log("Stuck");
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Work");
        if (col.gameObject.tag == "Fireball")
        {
            Debug.Log("Health left: " + health);
            health -= 10f;
        }
    }
}
