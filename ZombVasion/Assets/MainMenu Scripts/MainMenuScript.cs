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

    public void PlayBTN()
    {
        SceneManager.LoadScene("GamePlayScene");
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
