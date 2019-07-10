using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("_____"))
        {
            transform.parent.GetComponent<PeytonEnemyAI>().CollisionDetectedInvisWall(this);
        } else {
            transform.parent.GetComponent<PeytonEnemyAI>().CollisionDetected(this);
        }
    }
}
