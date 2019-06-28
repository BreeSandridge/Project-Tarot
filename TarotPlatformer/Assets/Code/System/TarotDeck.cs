using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotDeck : MonoBehaviour {

    public static TarotCard[] deck = new TarotCard[1];
    public static bool[] contains = new bool[1];
	// Use this for initialization
	void Start () {
        // The magician card
        deck[0] = new TheMagician();
        contains[0] = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // col is the trigger object we collided with
    void OnTriggerEnter2D(Collider2D col) {
        //example code 
        if (col.tag == "Card") {
            Destroy(col.gameObject); // remove the coin
            NewCard();
        }
    }

    private void NewCard() {
        contains[0] = true;
    }
}
