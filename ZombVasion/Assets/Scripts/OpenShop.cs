using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shopMenu;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shopMenu.SetActive(true);
            gameManager.gamePaused = true;
        }
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shopMenu.SetActive(false);
            gameManager.gamePaused = false;
        }
  
    }
}
