using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour { 
    public GameObject obj;
    Vector3 pos;

    public void Enemy()

    {
        pos = transform.position;

        if (Enemy.dir.Player == true)
        {
            pos += new Vector3(1, 0, 0);
        }
        else
        {
            pos += new Vector3(-1, 0, 0);
        }
      Instantiate(obj, pos, Quaternion.identity);
    }
}

