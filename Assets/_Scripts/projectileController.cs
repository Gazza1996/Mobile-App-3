using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    public float missileSpeed;

    Rigidbody2D RB;

    // Use this for initialization
    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();

        RB.AddForce(new Vector2(1, 0) * missileSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
		
	}
}