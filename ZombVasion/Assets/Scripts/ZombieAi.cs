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

    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject target;

    public LayerMask targetMask, obstructionMask;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
        rb = this.GetComponent<Rigidbody2D>();

        StartCoroutine(FovRoutine());
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

    private IEnumerator FovRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius,targetMask);
        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(Physics.Raycast(transform.position, directionToTarget,distanceToTarget, obstructionMask))
                {
                    playerSeen = false;
                }
                else
                {
                    playerSeen = true;
                }
            }
            else
            {
                playerSeen = false;
            }
        }
        else if(playerSeen)
        {
            playerSeen = false;
        }
    }
}
