using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject zombie;


    public bool playerIsDead = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        zombie.transform.position = gameObject.transform.position;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0)
        {
            playerIsDead = true;
            Destroy();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }





    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Healing(int healing)
    {
        currentHealth += healing;
    }

    private void Destroy()
    {
        zombie.SetActive(true);
        Destroy(gameObject);
       
    }
}
