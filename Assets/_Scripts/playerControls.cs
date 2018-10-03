using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

    // variables
    public float maxSpeed;
    
    Rigidbody2D RB;
    Animator myAnim;
    bool facingRight;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        RB.velocity = new Vector2(move * maxSpeed, RB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }else if(move < 0 && facingRight){
            flip();
        }
   
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
