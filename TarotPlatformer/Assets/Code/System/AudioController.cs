using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {


    //Music
    public AudioClip TitleScreen;
    public AudioClip Castle;
    public AudioClip Boss;


    public AudioClip sword_contact;
    public AudioClip player_walk_grass;
    public AudioClip player_walk;
    public AudioClip player_jump;
    public AudioClip holy_sound;
    public AudioClip hit_sound_effect;
    public AudioClip heal;
    public AudioClip fireball;
    public AudioClip fire_sword_spawn;
    public AudioClip door_open;
    public AudioClip chest_open;
    public AudioClip card_pickup;
    public AudioClip card_1;
    public AudioClip card_2;
    public AudioClip card_3;
    public AudioClip boss_death;
    public AudioClip menu_select;
    public AudioClip door_opening_sound_effects;
    public AudioClip cape_flap;


    //int[] cardNum = new int[3];
    //bool card;


    AudioSource audio;


    string scene;

    // Play default sound
    void Start()
    {
        audio = this.GetComponent<AudioSource>();


        scene = SceneManager.GetActiveScene().name;

        if (scene.Equals("Main_Menu") || scene.Equals("Tutorial") || scene.Equals("Game")) {
            audio.clip = TitleScreen;
        } else if (scene.Equals("Level1Castle")) {
            audio.clip = Castle;
        } else if (scene.Equals("BossRoom"))


        audio.loop = true;

        audio.Play();

        
    }

    void Update() {
        if (GameManager.jump)
        {
            audio.PlayOneShot(player_jump, 0.5f);
            GameManager.jump = false;
            //cape_flap.PlayDelayed(1f);
            
        }

        if (GameManager.fbAtk)
        {
            audio.PlayOneShot(fireball, 0.5f);
            GameManager.fbAtk = false;
        }

        if (GameManager.walk)
        {
            if(scene.Equals("Tutorial"))
            {
                audio.PlayOneShot(player_walk_grass, 0.5f);   
            }

            else
            {
                audio.PlayOneShot(player_walk, 0.5f);
            }
        }
    }    
}
