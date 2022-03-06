using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestScript : MonoBehaviour
{


    public GameObject E;
    public GameObject textBox;

    public GameObject questIcon;
    public int questNum = 1;
    public int questID;
    public bool questCompleted;

    public GameManager gameManager;

    bool talking;
    bool talked;

    bool playerClose;

    public TextMeshProUGUI mainQuestsText;
    public TextMeshProUGUI questText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (questNum)
        {
            case 1:
                questText.text = "- Your first mission is to destroy that plague heart inside the red house. Be careful the house is swarming with zombies. Follow the road.";
                break;
            case 2:
                questText.text = "Now destory the plague heart inside the gray house. This time it will be more difficult";
                break;


            default:
                break;
        }

        if (talked == true)
        {
            questIcon.SetActive(false);
        }
        else
        {
            questIcon.SetActive(true);

        }


        if (textBox.activeInHierarchy == false)
        {
            
                talking = false;

        }
        else if(textBox.activeInHierarchy == true)
        {
                talking = true;
        }
        
        if(talked == true)
        {
            switch (questNum)
            {
                case 1:
                    mainQuestsText.text = "- Destroy the plague heart inside the red building";
                    break;
                case 2:
                    mainQuestsText.text = "- Destroy the plague heart inside the gray Building";
                    break;


                default:
                    break;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            E.SetActive(false);

            if (talking == false && playerClose == true)
            {
                textBox.SetActive(true);
            }
            else if(talking == true && playerClose == true)
            {
                talked = true;
                textBox.SetActive(true);
                textBox.SetActive(false);
            }
         

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerClose = true;

            E.SetActive(true);

        }
    }
  

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerClose = false;
            E.SetActive(false);
            textBox.SetActive(false);
            talking = false;

        }
    }

    public void questComplete(int questID)
    {
        switch (questID)
        {
            case 1:
                gameManager.receiveXp(15);
                gameManager.receiveCoins(10);
                questNum = 2;
                talked = false;
                mainQuestsText.text = "";

                break;
            case 2:
                gameManager.receiveXp(30);
                gameManager.receiveCoins(20);
                questNum = 3;
                talked = false;
                mainQuestsText.text = "";
                break;

            default:
                break;
        }
      
    }
}
