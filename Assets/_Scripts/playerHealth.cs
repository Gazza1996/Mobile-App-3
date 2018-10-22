using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject death;

    public restart gameManager;

    float cHealth;

    playerControls controlMovement;

    // HUD var
    public Slider healthBar;
    public Image damageScreen;
    public Text gameOver;
    public Text winGameTxt;

    bool damaged = false;

    Color flash = new Color(0f, 0f, 0f, .5f);
    float smooth = 5f;


    // Use this for initialization
    void Start()
    {
        cHealth = fullHealth;

        controlMovement = GetComponent<playerControls>();

        //HUD
        healthBar.maxValue = fullHealth;
        healthBar.value = fullHealth;

        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = flash;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smooth * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        cHealth -= damage;
        healthBar.value = cHealth;

        damaged = true;

        if (cHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float health)
    {
        cHealth += health;
        if (cHealth > fullHealth) cHealth = fullHealth;
        healthBar.value = cHealth;
    }

    public void makeDead()
    {
        Instantiate(death, transform.position, transform.rotation);
        Destroy(gameObject);
        damageScreen.color = flash;

        Animator gameOverAnimator = gameOver.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");

        gameManager.restartGame();
    }

    public void gameWin()
    {
        Destroy(gameObject);
        gameManager.restartGame();

        Animator winGameAnimator = winGameTxt.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");


    }
}
