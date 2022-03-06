using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject DeathScreen;
    public Animator DeathScreenShowAnim;
    public float DeathFadeDelay = 0f;
    bool startFadeDelayTimer = false;
    public GameObject zombie;
    public GameObject player;
    public GameObject UI;
    public Slider levelSlider;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelText;

    public float coins;

    public float xpNedded;
    public float currentXp;
    public int level;

    public PlayerHealth playerHealth;
    public AudioSource audioSource;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        coinText.text = coins.ToString();


        levelMethod();

        if (player != null)
        {
            zombie.transform.position = player.transform.position;
        }
      

        if(playerHealth.playerIsDead == true)
        {
            startFadeDelayTimer = true;
            zombie.SetActive(true);
            UI.SetActive(false);
            Destroy(player);
        }

        if (startFadeDelayTimer == true)
        {
            DeathFadeDelay += Time.deltaTime;
        }
        if (DeathFadeDelay >= 2f)
        {
            print("Test");
            startFadeDelayTimer = false;
            PlayDeathScreenAnim();
            DeathFadeDelay = 0f;
        }
    }

    private void PlayDeathScreenAnim()
    {
        DeathScreen.SetActive(true);
        DeathScreenShowAnim.Play("FadeIn");
 
    }

    public void receiveCoins(float coinsToGet)
    {
        coins += coinsToGet;
    }

    public void receiveXp(float xpToGet)
    {
        currentXp += xpToGet;
    }

    void levelMethod()
    {
        levelText.text = "Level: " + level.ToString();

        levelSlider.value = currentXp;
        levelSlider.maxValue = xpNedded;

        if(currentXp >= xpNedded)
        {
            level += 1;
            currentXp = 0;
            xpNedded *= 1.25f;
        }

    }
}
