using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    [Header("Resource Text"), Space(10)]
    public Text moneyText;
    public Text foodText;
    public Text thirstText;
    public Text sleepText;
    public Text healthText;
    public Text energyText;

    [Header("Resource Sliders"), Space(10)]
    public Slider foodSlider;
    public Slider thirstSlider;
    public Slider sleepSlider;
    public Slider healthSlider;
    public Slider energySlider;

    private ResourceHandler _resources;

    private void Start()
    {
        _resources = FindObjectOfType<ResourceHandler>();
    }
    private void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        moneyText.text = "$" + _resources.Money.ToString("N0");

        MonitorFood();
        MonitorThirst();
        MonitorSleep();
        MonitorHealth();
        EnergySlider();
    }

    void MonitorFood()
    {
        if (foodText.text != _resources.Food.ToString())
        {
            foodText.text = _resources.Food.ToString("N0") + "/" + _resources.MaxFood.ToString("N0");
            foodSlider.value = (float)_resources.Food / _resources.MaxFood;
        }
    }
    void MonitorThirst()
    {
        if (thirstText.text != _resources.Thirst.ToString())
        {
            thirstText.text = _resources.Thirst.ToString("N0") + "/" + _resources.MaxThirst.ToString("N0");
            thirstSlider.value = (float)_resources.Thirst / _resources.MaxThirst;
        }
    }
    void MonitorSleep()
    {
        if (sleepText.text != _resources.Sleep.ToString())
        {
            sleepText.text = _resources.Sleep.ToString("N0") + "/" + _resources.MaxSleep.ToString("N0");
            sleepSlider.value = (float)_resources.Sleep / _resources.MaxSleep;
        }
    }
    void MonitorHealth()
    {
        if (healthText.text != _resources.Health.ToString())
        {
            healthText.text = _resources.Health.ToString("N0") + "/" + _resources.MaxHealth.ToString("N0");
            healthSlider.value = (float)_resources.Health / _resources.MaxHealth;
        }
    }
    void EnergySlider()
    {
        if (energyText.text != _resources.Energy.ToString())
        {
            energyText.text = _resources.Energy.ToString("N0") + "/" + _resources.MaxEnergy.ToString("N0");
            energySlider.value = (float)_resources.Energy / _resources.MaxEnergy;
        }
    }
}
