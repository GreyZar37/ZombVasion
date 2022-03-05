using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    ZombieAi zombieAi;

    // Start is called before the first frame update
    void Start()
    {
        zombieAi = GetComponent<ZombieAi>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0)
        {
            Destroy();

        }
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        zombieAi.playerSeen = true;

    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
