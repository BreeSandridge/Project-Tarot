using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {

    Transform sight;

    bool CanSee;

    float Range = 100.0f;

    public Transform Target;

    // Use this for initialization
    void Start () {
        

    }

    

    void Update()
    {

/*        sight.transform.LookAt(Target);

        if (Physics.Raycast(sight.transform.position, sight.transform.forward, Range)) {

            CanSee = false;

        }

        else
        {

            CanSee = true;

        }

        Debug.Log("In sight: " + CanSee);*/

    }
}
