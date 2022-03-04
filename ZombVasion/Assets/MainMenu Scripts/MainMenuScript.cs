using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject PlayButton;
    public GameObject OptionsButton;
    public GameObject QuitButton;

    public float DelayTime = 0f;
    public bool startTimer;

    private void Update()
    {
        if(startTimer == true)
        {
            DelayTime += Time.deltaTime;
        }

        if(DelayTime >= 2f)
        {
            SceneManager.LoadScene("GamePlayScene");
        }
    }

    public void PlayBTN()
    {
        startTimer = true;
    }

    public void OptionsBTN()
    {
        print("OptionsClicked");
    }

    public void QuitBTN()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ&t=4s");
        Application.Quit();
    }
}
