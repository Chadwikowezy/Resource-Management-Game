using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void MoneyProduction()
    {
        _gameManager.CurrentProduction = ProductionState.Money;
    }
    public void SleepProduction()
    {
        _gameManager.CurrentProduction = ProductionState.Sleep;
    }
    public void EnergyProduction()
    {
        _gameManager.CurrentProduction = ProductionState.Energy;
    }
}
