using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float coolDown;
    float coolDownTimer;

    

    public Pathfinding.AIDestinationSetter pathfinding;

    float timerSight;
    public float maxTimerSight;

    public Transform target;
    public bool playerSeen;
    public float distence;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = this.GetComponent<Rigidbody2D>();
        timerSight = maxTimerSight;
    }


    void Update()
    {
     
        coolDownTimer -= Time.deltaTime;
        timerSight -= Time.deltaTime;
        
        if(target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            if (dist <= 10)
            {
                playerSeen = true;
            }
        }
       
     

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

        if(timerSight <= 0)
        {
            playerSeen = false;
            timerSight = maxTimerSight;
        }

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
