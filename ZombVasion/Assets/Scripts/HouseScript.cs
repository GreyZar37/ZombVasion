using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    public GameObject roof;
    public GameObject heartLife;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (heartLife != null)
            {
                heartLife.SetActive(true);

            }
            InsideAHouse.insideHouse = true;
            roof.SetActive(false);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            roof.SetActive(true);
            if(heartLife != null)
            {
                heartLife.SetActive(false);

            }
            InsideAHouse.insideHouse = false; 

        }
    }
   
}
