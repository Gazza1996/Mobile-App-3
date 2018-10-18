using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootHeart : MonoBehaviour {

    public float healthAmt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth health = other.gameObject.GetComponent<playerHealth>();
            health.addHealth(healthAmt);
            Destroy(gameObject);
        }
    }
}
