using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlagueHeartHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public int questID;
   

    public Slider slider;
    public QuestScript quest;

    // Start is called before the first frame update
    void Start()
    {
        quest = FindObjectOfType<QuestScript>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {


        slider.value = currentHealth;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0)
        {
            Destroy();

        }
    }

  
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    
    }

    private void Destroy()
    {
        quest.questComplete(questID);
        Destroy(gameObject);
    }
}
