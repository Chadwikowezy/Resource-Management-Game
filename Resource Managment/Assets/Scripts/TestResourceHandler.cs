using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResourceHandler : MonoBehaviour
{
    public ResourceHandler resourceHandler;
    public GameManager gameManager;

	void Start ()
    {
        resourceHandler = FindObjectOfType<ResourceHandler>();
        gameManager = FindObjectOfType<GameManager>();
	}
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            gameManager.CurrentGameState = (GameState)((int)gameManager.CurrentGameState + 1);
        else if (Input.GetKeyDown(KeyCode.W))
            gameManager.CurrentGameState = (GameState)((int)gameManager.CurrentGameState - 1);
    }
}
