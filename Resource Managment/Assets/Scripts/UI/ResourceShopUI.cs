using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceShopUI : MonoBehaviour
{
    [Header("Tabs")]
    public GameObject foodTab;
    public GameObject thirstTab;
    public GameObject sleepTab;
    public GameObject healthTab;
    public GameObject energyTab;

    [Header("Menus")]
    public GameObject foodMenu;
    public GameObject thirstMenu;
    public GameObject sleepMenu;
    public GameObject healthMenu;
    public GameObject energyMenu;

    private GameObject _activeMenu;
    private ResourceHandler _resourceHandler;
    private List<GameObject> _allTabs = new List<GameObject>();

    private void Start()
    {
        InitializeMenus();
    }

    void InitializeMenus()
    {
        if (_resourceHandler == null)
            _resourceHandler = FindObjectOfType<ResourceHandler>();

        _activeMenu = foodMenu;

        _allTabs.Clear();
        _allTabs.Add(foodTab);
        _allTabs.Add(thirstTab);
        _allTabs.Add(sleepTab);
        _allTabs.Add(healthTab);
        _allTabs.Add(energyTab);
    }
    void SetTab(GameObject tab)
    {
        for (int i = 0; i < _allTabs.Count; i++)
            if (_allTabs[i] != tab)
            {
                _allTabs[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.75f);
                _allTabs[i].transform.SetAsFirstSibling();
            }

        tab.transform.SetAsLastSibling();
        tab.GetComponent<Image>().color = Color.white;
    }
    void SetActiveMenu(GameObject menu)
    {
        _activeMenu.SetActive(false);
        _activeMenu = menu;
        _activeMenu.SetActive(true);
    }
    void BuyFood(int amount)
    {
        int cost = (int)Mathf.Round(amount * 0.8f);

        if (_resourceHandler.Money < cost || _resourceHandler.Food == _resourceHandler.MaxFood)
            return;

        _resourceHandler.Money -= cost;
        _resourceHandler.Food += amount;
    }
    void BuyThirst(int amount)
    {
        int cost = (int)Mathf.Round(amount * 0.8f);

        if (_resourceHandler.Money < cost || _resourceHandler.Thirst == _resourceHandler.MaxThirst)
            return;

        _resourceHandler.Money -= cost;
        _resourceHandler.Thirst += amount;
    }
    void BuySleep(int amount)
    {
        int cost = (int)Mathf.Round(amount * 0.8f);

        if (_resourceHandler.Money < cost || _resourceHandler.Sleep == _resourceHandler.MaxSleep)
            return;

        _resourceHandler.Money -= cost;
        _resourceHandler.Sleep += amount;
    }

    //Tabs
    public void FoodTab()
    {
        SetTab(foodTab);
        SetActiveMenu(foodMenu);
    }
    public void ThirstTab()
    {
        SetTab(thirstTab);
        SetActiveMenu(thirstMenu);
    }
    public void SleepTab()
    {
        SetTab(sleepTab);
        SetActiveMenu(sleepMenu);
    }
    public void HealthTab()
    {
        SetTab(healthTab);
        SetActiveMenu(healthMenu);
    }
    public void EnergyTab()
    {
        SetTab(energyTab);
        SetActiveMenu(energyMenu);
    }

    //Buttons
    public void Foodx1()
    {
        BuyFood(1);
    }
    public void Foodx5()
    {
        BuyFood(5);
    }
    public void Foodx10()
    {
        BuyFood(10);
    }
    public void Thirstx1()
    {
        BuyThirst(1);
    }
    public void Thirstx5()
    {
        BuyThirst(5);
    }
    public void Thirstx10()
    {
        BuyThirst(10);
    }
    public void Sleepx1()
    {
        BuySleep(1);
    }
    public void Sleepx5()
    {
        BuySleep(5);
    }
    public void Sleepx10()
    {
        BuySleep(10);
    }
}
