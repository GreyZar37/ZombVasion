using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{

    public GameObject roof;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            roof.SetActive(false);
            InsideAHouse.insideHouse = true;
        
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            roof.SetActive(true); ;
            InsideAHouse.insideHouse = false; 

        }
    }
   
}
