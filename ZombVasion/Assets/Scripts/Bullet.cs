using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int playerDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.tag == "Enemy" || other.tag == "PlaguedZombieLvl1" || other.tag == "PlaguedZombieLvl2")

        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
            Destroy(gameObject);
        }
        else if (other.tag == "PlagueHeart")

        {
            other.gameObject.GetComponent<PlagueHeartHealth>().TakeDamage(playerDamage);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")

        {
         
            Destroy(gameObject);
        }

     

    }




}
