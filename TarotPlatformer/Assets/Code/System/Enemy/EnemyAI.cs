using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject fireball;
    public GameObject player;
    public int counter;
    Vector3 pos;
    Rigidbody2D rb2D;

    private void Update()
    {
        pos = transform.position;
        Vector3 pPos = player.transform.position;
        float len = (pos - pPos).magnitude;
        int dir = 0;
        if(pos.x > pPos.x)
        {
            dir = -1;
        }
        else
        {
            dir = +1;
        }

        if (len < 5)
        {
            Instantiate(fireball, pos, Quaternion.identity);
            fireball.GetComponent<Fireball>().speed *= dir;
        }
       
    }
    
    
  
    private void Start()
    {
        
    }
}


