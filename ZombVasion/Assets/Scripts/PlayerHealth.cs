using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject zombie;

    public bool playerIsDead = false;

    public GameObject DeathScreen;
    public Animator DeathScreenShowAnim;
    public float DeathFadeDelay = 0f;
    bool startFadeDelayTimer = false;


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
            startFadeDelayTimer = true;
            playerIsDead = true;
            Destroy();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(startFadeDelayTimer == true)
        {
            DeathFadeDelay += Time.deltaTime;
        }
        if(DeathFadeDelay >= 2f)
        {
            print("Test");
            startFadeDelayTimer = false;
            PlayDeathScreenAnim();
            DeathFadeDelay = 0f;
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
    }

    private void PlayDeathScreenAnim()
    {
        DeathScreen.SetActive(true);
        DeathScreenShowAnim.Play("FadeIn");
        Destroy(gameObject);
    }
}
