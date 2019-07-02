using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotDeck : MonoBehaviour {

    public MyLinkedList<TarotCard> deck = new MyLinkedList<TarotCard>();
    MyLinkedList<TarotCard> remaining = new MyLinkedList<TarotCard>();



   
    public bool theMagician = false;

	// Use this for initialization
	void Start () {
        // The magician card
        deck.Add(new TheMagician());
        deck.Add(new TheChariot());

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
        int index = Random.Range(0, remaining.Count - 1);
        deck.Add(remaining[index]);
        remaining.RemoveAt(index);
    }

    public static void ability() {
        if (Input.GetKeyDown(KeyCode.E)) {
           theMagician = true;
        }
    }

    internal class TheMagician
    {
    }
}
