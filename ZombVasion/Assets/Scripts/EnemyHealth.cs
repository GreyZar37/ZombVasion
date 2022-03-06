using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float coinsToGive;
    public float xpToGive;

    public GameObject gameManager;

    ZombieAi zombieAi;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
        gameManager.GetComponent<GameManager>().audioSource.Play();
        zombieAi.playerSeen = true;

    }

    private void Destroy()
    {
        gameManager.GetComponent<GameManager>().receiveCoins(coinsToGive);
        gameManager.GetComponent<GameManager>().receiveXp(xpToGive);
        Destroy(gameObject);
    }
}
