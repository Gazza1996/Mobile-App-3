using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject death;

    float cHealth;

    playerControls controlMovement;

    // HUD var
    public Slider healthBar;

    // Use this for initialization
    void Start()
    {
        cHealth = fullHealth;

        controlMovement = GetComponent<playerControls>();

        //HUD
        healthBar.maxValue = fullHealth;
        healthBar.value = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        cHealth -= damage;
        healthBar.value = cHealth;

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
