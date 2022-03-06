using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Slider slider;

    public GameObject gameManager;


    public bool playerIsDead = false;
    public AudioClip hurt;

  
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0)
        {
            playerIsDead = true;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(hurt);

    }

    public void Healing(int healing)
    {
        currentHealth += healing;
    }

   
}
