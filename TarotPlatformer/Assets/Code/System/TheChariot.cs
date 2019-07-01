using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChariot : TarotCard {
  //  public float speed = 3f;
    public  Vector3 playerPos = new Vector3(0, 0, 0);
    public GameObject Player;
    //public Player.GetComponent;
    public override void Ability()
    {
     //  if (TarotDeck.TheMagician)
        {

            // playerPos = transform.position;
            //  var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
            //    var movement = input * speed;

          //  Player(speed*1.25); 
        
        }
    }

    public override void Start()
    {

       float Chariotspeed = gameObject.GetComponent<Player>(speed);

    }

    public override void Update()
    {

    }


}
