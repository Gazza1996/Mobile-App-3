using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public float enemeyHealthMax; // maximum health of enemy

    float chealth; // enemys current health state

	// Use this for initialization
	void Start () {
        chealth = enemeyHealthMax;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        chealth -= damage;
        if (chealth <= 0) makeDead();
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
