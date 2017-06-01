using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float productionUpdateRate;
    public float usageUpdateRate;

    private float _currentProductionTime;
    private float _currentUsageTime;
    private GameState _currentGameState;
    private PlayState _currentPlayState;
    private ProductionState _currentProduction;
    private ResourceHandler _resoruceHandler;
    
    //Properties
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            _currentGameState = value;

            //Add if statements for state change

        }
    }
    public PlayState CurrentPlayState
    {
        get { return _currentPlayState; }
        set
        {
            _currentPlayState = value;
            
            //Add if statements for state change

        }
    }
    public ProductionState CurrentProduction
    {
        get { return _currentProduction; }
        set
        {
            _currentProduction = value;

            //Add if statements for state change

        }
    }

    private void Start()
    {
        _resoruceHandler = FindObjectOfType<ResourceHandler>();
    }
    private void FixedUpdate()
    {
        MonitorTime();
    }

    void MonitorTime()
    {
        if (_currentGameState == GameState.Paused)
            return;
        else if (_currentGameState == GameState.Play)
        {
            _currentProductionTime += Time.fixedDeltaTime;
            _currentUsageTime += Time.fixedDeltaTime;
        }
        else if (_currentGameState == GameState.Half_Speed)
        {
            _currentProductionTime += Time.fixedDeltaTime / 2;
            _currentUsageTime += Time.fixedDeltaTime / 2;
        }
        else if (_currentGameState == GameState.Double_Speed)
        {
            _currentProductionTime += Time.fixedDeltaTime * 2;
            _currentUsageTime += Time.fixedDeltaTime * 2;
        }
        

        if (_currentProductionTime >= productionUpdateRate)
        {
            ProduceResources();
            _currentProductionTime = 0;
        }

        if (_currentUsageTime >= usageUpdateRate)
        {
            UseResources();
            _currentUsageTime = 0;
        }
    }
    void ProduceActiveResource()
    {
        if (_currentProduction == ProductionState.Money)
            _resoruceHandler.Money += _resoruceHandler.Income;
        else if (_currentProduction == ProductionState.Energy)
            _resoruceHandler.Energy += _resoruceHandler.EnergyProduction;
        else if (_currentProduction == ProductionState.Sleep)
            _resoruceHandler.Sleep += _resoruceHandler.SleepRecovery;
    }
    void ProduceResources()
    {
        _resoruceHandler.Food += _resoruceHandler.FoodProduction;
        _resoruceHandler.Thirst += _resoruceHandler.ThirstProduction;
        _resoruceHandler.Health += _resoruceHandler.HealthRecovery;

        ProduceActiveResource();
    }
    void UseResources()
    {
        _resoruceHandler.Money -= _resoruceHandler.OperationCost;
        _resoruceHandler.Food -= _resoruceHandler.FoodUsage;
        _resoruceHandler.Thirst -= _resoruceHandler.ThirstUsage;
        _resoruceHandler.Energy -= _resoruceHandler.EnergyUsage;
        _resoruceHandler.Sleep -= _resoruceHandler.SleepUsage;
    }

    public void AddTapMoney()
    {
        if (_resoruceHandler.Energy < 1 || _resoruceHandler.Sleep < 1)
            return;

        _resoruceHandler.Sleep--;
        _resoruceHandler.Money += _resoruceHandler.IncomePerTap;
    }
}
