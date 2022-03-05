using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public float speed;
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float coolDown;
    float coolDownTimer;

    public float distence;

    public ZombieSight zombieSight;



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
     
        coolDownTimer -= Time.deltaTime;
        /*
        if(zombieSight.playerIsSeen == true)
        {
            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            transform.up = direction;

            if (Vector2.Distance(transform.position, target.position) > distence)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }*/







    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (coolDownTimer <= 0 && collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            coolDownTimer = coolDown;
        }
    }
 
}
