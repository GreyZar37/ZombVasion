using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    //FADE IN
    public GameObject FadeInCanvas;
    float FadeTimer = 0f;

    //WEAPON SMITH
    public GameObject[] ShopMenus;
    public GameObject ShopMenu;
    public GameManager gameManager;

    bool MenuActive = true;

    public void TryAgain()
    {
        SceneManager.LoadScene("GamePlayScene 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //WEAPON SMITH
    public void OnAmmoCategoryClick()
    {
        gameManager.gamePaused = true;
        ShopMenus[0].SetActive(true);

        ShopMenus[1].SetActive(false);
        ShopMenus[2].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnAttachCategoryClick()
    {
        gameManager.gamePaused = true;

        ShopMenus[1].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[2].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnWeaponsCategoryClick()
    {
        gameManager.gamePaused = true;

        ShopMenus[2].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[1].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnExtrasCategoryClick()
    {
        gameManager.gamePaused = true;

        ShopMenus[3].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[1].SetActive(false);
        ShopMenus[2].SetActive(false);
    }

    public void CloseMenu()
    {
        gameManager.gamePaused = false;

        MenuActive = false;
        ShopMenu.SetActive(false);
    }

    private void Update()
    {
        FadeTimer += Time.deltaTime;

        if(FadeTimer >= 2.0f)
        {
            FadeInCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(MenuActive == true)
            {
                gameManager.gamePaused = false;

                ShopMenu.SetActive(false);
                MenuActive = false;
            }
        }
    }
}
