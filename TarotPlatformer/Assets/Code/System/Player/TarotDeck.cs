using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotDeck : MonoBehaviour {

    static TheMagician magician;
    TheChariot Chariot;

    static bool[] abilities = new bool[3];
    // Use this for initialization
    void Start () {
        // The magician card
        abilities[0] = false;

        // The Chariot
        abilities[1] = false;

        // Sun
        abilities[2] = false; 
        
	}
	
	// Update is called once per frame
	void Update () {
        NewCard();
	}

    // col is the trigger object we collided with
    /*void OnCollisionTrigger2D(Collider2D col) {
        Debug.Log("got here");

        //example code 
        if (col.CompareTag("Card")) {
            Destroy(col.gameObject); // remove the coin
            NewCard();
        } else if (col.gameObject.name == "TestCol")
        {
            Destroy(col.gameObject);
        }

    }
    */
    public static void NewCard() {
        for (int ignoreThisInt = 0; GameManager.newCards > 0; GameManager.newCards--) {
            for (int i = 0; i < abilities.Length; i++)
            {
                if (!abilities[i])
                {
                    abilities[i] = true;
                    break;
                }
            }
        }
    }

    public static void ability() {
        if (Input.GetKeyDown(KeyCode.Space) && abilities[0]) {
            GameManager.magicianAbility = true;
        }

        if (Input.GetKey(KeyCode.LeftControl) && abilities[1]) {
            GameManager.chariotAbility = true;
        }
    }

}
