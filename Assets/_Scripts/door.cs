﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    bool activated = false;
    public Transform spawn;
    public GameObject star;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !activated)
        {
            activated = true;
            Instantiate(star, spawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}