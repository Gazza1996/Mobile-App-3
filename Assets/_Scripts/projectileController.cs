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

        if(transform.localRotation.z>0)
            RB.AddForce(new Vector2(-1, 0) * missileSpeed, ForceMode2D.Impulse);
        else   RB.AddForce(new Vector2(1, 0) * missileSpeed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void removeForce()
    {
        RB.velocity = new Vector2(0,0);
    }
}