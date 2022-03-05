using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DeathScreen;
    public Animator DeathScreenShowAnim;
    public float DeathFadeDelay = 0f;
    bool startFadeDelayTimer = false;
    public GameObject zombie;
    public GameObject player;
    public GameObject UI;

    public PlayerHealth playerHealth;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
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


}
