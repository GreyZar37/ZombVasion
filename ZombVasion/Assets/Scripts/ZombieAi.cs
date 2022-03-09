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
        
        RaycastHit2D hitInfo = Physics2D.Raycast(sight.position,new Vector2(target.position.x, target.position.y), sightDistance);
        print(hitInfo.point);
        Debug.DrawLine(sight.position, hitInfo.point, Color.red);
        if (hitInfo.collider != null)
        {
           
            if (hitInfo.collider.tag == "Player")
            {

                print("Was Seen");
            }


        }


        }

}
