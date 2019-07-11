using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordmanager : MonoBehaviour {
    public GameObject swordprefab;
    Transform[] spawnPoints;
    public float firstShotDelay;
    public float fireRate;
	// Use this for initialization
	void Start () {
        spawnPoints = transform.GetComponentsInChildren<Transform>();
        spawnPoints[0] = null;
        InvokeRepeating("Drop", firstShotDelay, fireRate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Drop()
    {
        foreach (Transform i in spawnPoints)
        {
            if(i!=null)
            {
               float swordtimer = Random.Range(0f, 10f);
               if(swordtimer <= 4f)
                {
                       Instantiate(swordprefab, i.position, i.rotation);
                }

                
            }
        }
    }
}
