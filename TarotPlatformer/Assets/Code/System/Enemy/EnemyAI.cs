using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public enum State
    {
        Walk,
        Attack,
        Die,
    }

    public bool dir = true;

    Rigidbody2D rb;
    public State state;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Walk;
        
    }


    void Update()
    {
        //DrawBounds();
        if (state == State.Walk) {
            if (dir) {
                rb.velocity = new Vector3(1, rb.velocity.y, 0);
            } else {
                rb.velocity = new Vector3(-1, rb.velocity.y, 0);
            }
        }
    }


    /*private void DrawBounds() {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;


        //bottom
        float botLeftX = transform.position.x - (width / 2);
        float botRightX = transform.position.x + (width / 2);
        float botY = transform.position.y - (height / 2);
        DrawLine(new Vector3(botLeftX, botY, 0), new Vector3(botRightX, botY, 0), Color.cyan, .03f);

    }*/

    public void changeState()
    {

    }

    private void walk() {

    }

    public void CollisionDetected(ChildCollider childScript)
    {
        print("child collided: " + childScript.name);
    }
}
