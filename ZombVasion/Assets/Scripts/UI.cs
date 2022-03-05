using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    //WEAPON SMITH
    public GameObject[] ShopMenus;
    public GameObject ShopMenu;

    bool MenuActive = true;

    public void TryAgain()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //WEAPON SMITH
    public void OnAmmoCategoryClick()
    {
        ShopMenus[0].SetActive(true);

        ShopMenus[1].SetActive(false);
        ShopMenus[2].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnAttachCategoryClick()
    {
        ShopMenus[1].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[2].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnWeaponsCategoryClick()
    {
        ShopMenus[2].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[1].SetActive(false);
        ShopMenus[3].SetActive(false);
    }

    public void OnExtrasCategoryClick()
    {
        ShopMenus[3].SetActive(true);

        ShopMenus[0].SetActive(false);
        ShopMenus[1].SetActive(false);
        ShopMenus[2].SetActive(false);
    }

    public void CloseMenu()
    {
        MenuActive = false;
        ShopMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(MenuActive == true)
            {
                ShopMenu.SetActive(false);
                MenuActive = false;
            }
        }
    }
}
