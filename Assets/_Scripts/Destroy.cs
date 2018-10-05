using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float alive;

	// Use this for initialization
	void Awake () {
        Destroy(gameObject, alive);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
