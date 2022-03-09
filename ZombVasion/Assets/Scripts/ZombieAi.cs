using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAi : MonoBehaviour
{
    /// <Basic Ai mechanics>
    private Rigidbody2D rb;

    public float coolDown;
    float coolDownTimer;

    public int damage;
    

    public Pathfinding.AIDestinationSetter pathfinding;


    public Transform target;

    /// <Ai Sight>
    public bool playerSeen;
    public float sightDistance;

    float timerSight;
    public float maxTimerSight;
    public Transform sight;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = this.GetComponent<Rigidbody2D>();
        timerSight = maxTimerSight;
    }


    void Update()
    {
        vision();


        coolDownTimer -= Time.deltaTime;
        timerSight -= Time.deltaTime;      
     

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

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            coolDownTimer = coolDown;
        }
    }

    public void vision()
    {

        RaycastHit2D hit = Physics2D.Raycast(sight.position, Vector2.up, sightDistance);


        Debug.DrawRay(sight.position, Vector2.up, Color.red, 2f);

        if (hit.collider != null)
        {
           
            if (hit.transform.tag == "Player")
            {

                print("Was Seen");
            }


        }


        }

}
