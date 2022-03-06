using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject BlackFadeScreenObj;

    public float DelayTime = 0f;
    public bool startTimer;

    public Animator anim;

    private void Update()
    {
        if(startTimer == true)
        {
            DelayTime += Time.deltaTime;
        }

        if(DelayTime >= 3f)
        {
            SceneManager.LoadScene("GamePlayScene 1");
        }
    }

    public void PlayBTN()
    {
        BlackFadeScreenObj.SetActive(true);
        startTimer = true;
        anim.Play("BlackScreenAnim");
    }

    public void OptionsBTN()
    {
        print("OptionsClicked");
    }

    public void QuitBTN()
    {
        Application.Quit();
    }
}
