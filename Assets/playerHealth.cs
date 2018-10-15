using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject death;

    float cHealth;

    playerControls controlMovement;

    // Use this for initialization
    void Start()
    {
        cHealth = fullHealth;

        controlMovement = GetComponent<playerControls>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        cHealth -= damage;

        if (cHealth <= 0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Instantiate(death, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
