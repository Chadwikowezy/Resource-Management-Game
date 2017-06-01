using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    //Serialize Almost everything for testing. Remove later.

    [Header("Current Resources"), Space(height: 10)]
    [SerializeField] private int _money;
    [SerializeField] private int _food;
    [SerializeField] private int _thirst;
    [SerializeField] private int _sleep;
    [SerializeField] private int _health;
    [SerializeField] private int _energy;

    [Header("Max Resources"), Space(height:10)]
    [SerializeField] private int _maxFood;
    [SerializeField] private int _maxThirst;
    [SerializeField] private int _maxSleep;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxEnergy;

    [Header("Resource Usage"), Space(height: 10)]
    [SerializeField] private int _income;
    [SerializeField] private int _operationCost;
    [SerializeField] private int _foodUsage;
    [SerializeField] private int _thirstUsage;
    [SerializeField] private int _sleepUsage;
    [SerializeField] private int _energyUsage;

    [Header("Resources Produced"), Space(height:10)]
    [SerializeField] private int _incomePerTap;
    [SerializeField] private int _foodProduction;
    [SerializeField] private int _thirstProduction;
    [SerializeField] private int _sleepRecovery;
    [SerializeField] private int _healthRecovery;
    [SerializeField] private int _energyProduction;

    //Properties
    public int Money
    {
        get { return _money; }
        set
        {
            _money = value;
            _money = Mathf.Clamp(_money, 0, _money);
        }
    }
    public int Food
    {
        get { return _food; }
        set
        {
            _food = value;
            _food = Mathf.Clamp(_food, 0, _maxFood);

            if (_food == 0)
                Health -= 1;
        }
    }
    public int Thirst
    {
        get { return _thirst; }
        set
        {
            _thirst = value;
            _thirst = Mathf.Clamp(_thirst, 0, _thirst);

            if (_thirst == 0)
                Health -= 1;
        }
    }
    public int Sleep
    {
        get { return _sleep; }
        set
        {
            _sleep = value;
            _sleep = Mathf.Clamp(_sleep, 0, _maxSleep);

            if (_sleep == 0)
                Health -= 1;
        }
    }
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            _health = Mathf.Clamp(_health, 0, _maxHealth);
        }
    }
    public int Energy
    {
        get { return _energy; }
        set
        {
            _energy = value;
            _energy = Mathf.Clamp(_energy, 0, _maxEnergy);
        }
    }

    public int MaxFood
    {
        get { return _maxFood; }
        set
        {
            _maxFood = value;
            _maxFood = Mathf.Clamp(_maxFood, 0, _maxFood);
        }
    }
    public int MaxThirst
    {
        get { return _maxThirst; }
        set
        {
            _thirst = value;
            _thirst = Mathf.Clamp(_thirst, 0, _thirst);
        }
    }
    public int MaxSleep
    {
        get { return _maxSleep; }
        set
        {
            _maxSleep = value;
            _maxSleep = Mathf.Clamp(_maxSleep, 0, _maxSleep);
        }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value;
            _maxHealth = Mathf.Clamp(_maxHealth, 0, _maxHealth);
        }
    }
    public int MaxEnergy
    {
        get { return _maxEnergy; }
        set
        {
            _maxEnergy = value;
            _maxEnergy = Mathf.Clamp(_maxEnergy, 0, _maxEnergy);
        }
    }


    public int OperationCost
    {
        get { return _operationCost; }
        set
        {
            _operationCost = value;
            _operationCost = Mathf.Clamp(_operationCost, 0, _operationCost);
        }
    }
    public int FoodUsage
    {
        get { return _foodUsage; }
        set
        {
            _foodUsage = value;
            _foodUsage = Mathf.Clamp(_foodUsage, 0, _foodUsage);
        }
    }
    public int ThirstUsage
    {
        get { return _thirstUsage; }
        set
        {
            _thirstUsage = value;
            _thirstUsage = Mathf.Clamp(_thirstUsage, 0, _thirstUsage);
        }
    }
    public int SleepUsage
    {
        get { return _sleepUsage; }
        set
        {
            _sleepUsage = value;
            _sleepUsage = Mathf.Clamp(_sleepUsage, 0, _sleepUsage);
        }
    }
    public int EnergyUsage
    {
        get { return _energyUsage; }
        set
        {
            _energyUsage = value;
            _energyUsage = Mathf.Clamp(_energyUsage, 0, _energyUsage);
        }
    }

    public int Income
    {
        get { return _income; }
        set
        {
            _income = value;
            _income = Mathf.Clamp(_income, 0, _income);
        }
    }
    public int FoodProduction
    {
        get { return _foodProduction; }
        set
        {
            _foodProduction = value;
            _foodProduction = Mathf.Clamp(_foodProduction, 0, _foodProduction);
        }
    }
    public int ThirstProduction
    {
        get { return _thirstProduction; }
        set
        {
            _thirstProduction = value;
            _thirstProduction = Mathf.Clamp(_thirstProduction, 0, _thirstProduction);
        }
    }
    public int SleepRecovery
    {
        get { return _sleepRecovery; }
        set
        {
            _sleepRecovery = value;
            _sleepRecovery = Mathf.Clamp(_sleepRecovery, 0, _sleepRecovery);
        }
    }
    public int HealthRecovery
    {
        get { return _healthRecovery; }
        set
        {
            _healthRecovery = value;
            _healthRecovery = Mathf.Clamp(_healthRecovery, 0, _healthRecovery);
        }
    }
    public int EnergyProduction
    {
        get { return _energyProduction; }
        set
        {
            _energyProduction = value;
            _energyProduction = Mathf.Clamp(_energyProduction, 0, _energyProduction);
        }
    }

    public int IncomePerTap
    {
        get { return _incomePerTap; }
        set
        {
            _incomePerTap = value;
            _incomePerTap = Mathf.Clamp(_incomePerTap, 0, _incomePerTap);
        }
    }
}
