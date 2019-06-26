using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TarotCard : MonoBehaviour {

    private string cardName;
    private int level;
    private float cooldown;
    private float lastCast = Time.time;
    public Sprite[] sprites;

    public abstract void Ability();

    // Use this for initialization
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();
}
