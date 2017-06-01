using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedUI : MonoBehaviour
{
    public GameObject centerButton;

    public Text currentSpeedText;

    public Sprite[] centerButtonImages;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void UpdateUI()
    {
        if (_gameManager.CurrentGameState == GameState.Paused)
        {
            centerButton.GetComponent<Image>().sprite = centerButtonImages[0];
            currentSpeedText.text = "x0";
        } 
        else if (_gameManager.CurrentGameState == GameState.Half_Speed)
        {
            centerButton.GetComponent<Image>().sprite = centerButtonImages[1];
            currentSpeedText.text = "x0.5";
        }
        else if (_gameManager.CurrentGameState == GameState.Play)
        {
            centerButton.GetComponent<Image>().sprite = centerButtonImages[1];
            currentSpeedText.text = "x1";
        }
        else if (_gameManager.CurrentGameState == GameState.Double_Speed)
        {
            centerButton.GetComponent<Image>().sprite = centerButtonImages[1];
            currentSpeedText.text = "x2";
        }
    }

    public void PlayPauseButton()
    {
        if (_gameManager.CurrentGameState == GameState.Paused)
            _gameManager.CurrentGameState = GameState.Play;
        else
            _gameManager.CurrentGameState = GameState.Paused;

        UpdateUI();
    }
    public void IncreaseSpeed()
    {
        if ((int)_gameManager.CurrentGameState < System.Enum.GetValues(typeof(GameState)).Length - 1)
            _gameManager.CurrentGameState = (GameState)((int)_gameManager.CurrentGameState + 1);

        UpdateUI();
    }
    public void DecreaseSpeed()
    {
        if (_gameManager.CurrentGameState > 0)
            _gameManager.CurrentGameState = (GameState)((int)_gameManager.CurrentGameState - 1);

        UpdateUI();
    }
}
