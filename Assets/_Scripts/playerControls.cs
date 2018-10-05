using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

    // Character Movement variables
    public float maxSpeed;

    // Character Jumping
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpH;
    
    Rigidbody2D RB;
    Animator myAnim;
    bool facingRight;

    // shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            RB.AddForce(new Vector2(0, jumpH));
        }

        // player shoot
        if (Input.GetAxisRaw("Fire1") > 0) fireGun();
    }

	void FixedUpdate () {

        // check for grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("grounded", grounded);

        myAnim.SetFloat("verticalSpeed", RB.velocity.y);

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

    void fireGun()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));


            }
        }
    }
}
