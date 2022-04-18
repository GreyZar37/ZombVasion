using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Range(0, 360)]
    public float fovAngle;
    public Transform fovPoint;

    
    public float sightRange;
    public float closeSightRange;

    public Transform target;
    public ZombieAi zombieAiScript;

  
    private void Awake()
    {
 
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > sightRange)
            {
                zombieAiScript.playerSeen = false;
            }
            if (Vector2.Distance(transform.position, target.position) < closeSightRange)
            {
                zombieAiScript.playerSeen = true;
            }
            Vector2 dir = target.position - fovPoint.position;
            float angle = Vector3.Angle(dir, fovPoint.up);
            RaycastHit2D hit = Physics2D.Raycast(fovPoint.position, dir, sightRange);

            if (angle < fovAngle / 2)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    zombieAiScript.playerSeen = true;
                }

            }
        }
       

       
        

        
        


    }
}
