using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public GameObject resourceShop;

    public GameObject shopButton;

    public Sprite shopImage,
                  exitImage;

    private GameObject _currentMenu;

    public void ResourceShopButton()
    {
        if (_currentMenu == null)
        {
            resourceShop.SetActive(true);
            _currentMenu = resourceShop;
            shopButton.GetComponent<Image>().sprite = exitImage;
        }
        else if (_currentMenu == resourceShop)
        {
            resourceShop.SetActive(false);
            _currentMenu = null;
            shopButton.GetComponent<Image>().sprite = shopImage;
        }
    }
}
