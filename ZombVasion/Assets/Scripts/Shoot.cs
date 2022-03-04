using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    public float currentTimer;
    public float playerCoolDowntimer = 1.5f;


    AudioSource gunShotSound;

    private void Start()
    {
        gunShotSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame

    void Update()
    {
        currentTimer -= Time.deltaTime;




        if (Input.GetButtonDown("Fire1") && currentTimer <= 0)
        {
            shoot();
            currentTimer = playerCoolDowntimer;


        }

        void shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        }
    }
}
