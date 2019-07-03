using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotDeck : MonoBehaviour {

    static TheMagician magician;
    TheChariot Chariot;

    static bool[] abilities = new bool[2];
    // Use this for initialization
    void Start () {
        // The magician card
        magician = new TheMagician();
        abilities[0] = false;

        TheChariot theChariot = new TheChariot();
        abilities[1] = false;
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
        for (int i = 0; i < abilities.Length; i++) {
            if (!abilities[i]) {
                abilities[i] = true;
                break;
            }
        }
    }

    public static void ability() {
        if (Input.GetKeyDown(KeyCode.E) && abilities[0]) {
            GameManager.magicianAbility = true;
        }
    }

}
