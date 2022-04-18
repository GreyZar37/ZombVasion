using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    [Header("Ai mechanics")]
    private Rigidbody2D rb;

    public float coolDown;
    float coolDownTimer;

    public int damage;

  

    public Pathfinding.AIDestinationSetter pathfinding;


   

    [Header ("Sight")]
    public bool playerSeen;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }


    void Update()
    {


        
        coolDownTimer -= Time.deltaTime;
     

        if (playerSeen == true && pathfinding != null)
        {
            pathfinding.enabled = true;
        }
        else
        {
            if(pathfinding != null)
            {
                pathfinding.enabled = false;

            }

        }

       

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (coolDownTimer <= 0 && collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            coolDownTimer = coolDown;
        }
    }

  
}
