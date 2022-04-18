using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{


    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    public float currentTimer;
    public float playerCoolDowntimer = 1.5f;

    public float currentTimerReload;
    public float playerCoolReload = 4f;

    public int magazine;
    public int ammoLeft;
    bool reloadSoundPlay;

    AudioSource audioSource;
    public AudioClip gunShot;
    public AudioClip reloadSound;

    public GameObject[] ammoImages;

    public GameObject gameManager;

    bool reloading;
    bool shot;

    Animator anim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTimerReload = playerCoolReload;
        ammoLeft = magazine;
        gameManager = GameObject.Find("GameManager");
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame

    void Update()
    {
        currentTimer -= Time.deltaTime;
        anim.SetBool("Reloading", reloading);
        anim.SetBool("Shot", shot);

        if (Input.GetKeyDown(KeyCode.R) && reloading == false)
        {
            reloading = true;
        }
        if (ammoLeft <= 0)
        {
            reloading = true;
        }
        reloadGun();

        if(currentTimer <= 0)
        {
            shot = false;
        }

        for (int i = 0; i < ammoLeft; i++)
        {
            ammoImages[i].SetActive(true);
        }


        if (Input.GetButtonDown("Fire1") && currentTimer <= 0 && ammoLeft > 0 && gameManager.GetComponent<GameManager>().gamePaused == false && reloading != true)
        {
            shoot();
            audioSource.PlayOneShot(gunShot);
            currentTimer = playerCoolDowntimer;

        }

        void shoot()
        {
          
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                shot = true;
                ammoImages[ammoLeft-1].SetActive(false);
                ammoLeft -= 1;
        }
        void reloadGun()
        {
            if(reloading == true)
            {
                if (reloadSoundPlay == false)
                {

                    audioSource.PlayOneShot(reloadSound);
                    reloadSoundPlay = true;
                }
                currentTimerReload -= Time.deltaTime;

                if (currentTimerReload <= 0)
                {
                    ammoLeft = magazine;
                    reloading = false;
                    reloadSoundPlay = false;
                    currentTimerReload = playerCoolReload;
                }
            }
       



}
    }
}
