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
}
