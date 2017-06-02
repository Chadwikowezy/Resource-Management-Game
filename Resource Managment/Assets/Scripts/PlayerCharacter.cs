using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;

    [Header("Target Movement Positions"), Space(10)]
    public RectTransform sleepPosition;
    public RectTransform moneyPosition;
    public RectTransform energyPosition;

    [Header("Player Images"), Space(10)]
    public GameObject movingPlayer;
    public GameObject sleepingPlayer;
    public GameObject moneyPlayer;
    public GameObject energyPlayer;

    private bool _isMoving;
    private float _currentSpeed;
    private RectTransform _currentTrargetTransform;
    private GameObject _currentlyActivePlayer;
    private GameManager _gameManager;
    private ProductionState _currentState;

    private void Start()
    {
        _currentlyActivePlayer = moneyPlayer;
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        MonitorProductionState();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MonitorProductionState()
    {
        if (_currentState == _gameManager.CurrentProduction)
            return;

        _currentState = _gameManager.CurrentProduction;

        if (_currentlyActivePlayer != movingPlayer)
            _currentlyActivePlayer.SetActive(false);

        movingPlayer.SetActive(true);
        SetMovePosition();
        _isMoving = true;
    }
    void SetMovePosition()
    {
        _currentSpeed = 0;

        if (_currentState == ProductionState.Sleep)
            _currentTrargetTransform = sleepPosition;
        else if (_currentState == ProductionState.Money)
            _currentTrargetTransform = moneyPosition;
        else if (_currentState == ProductionState.Energy)
            _currentTrargetTransform = energyPosition;
    }
    void MovePlayer()
    {
        if (!_isMoving)
            return;

        Vector3 playerPosition = movingPlayer.GetComponent<RectTransform>().position;
        Vector3 targetPosition = _currentTrargetTransform.GetComponent<RectTransform>().position;
        Vector3 newPosition = Vector3.Lerp(playerPosition, targetPosition, _currentSpeed * Time.fixedDeltaTime);

        _currentSpeed += moveSpeed * 0.01f;

        if ((movingPlayer.transform.position - _currentTrargetTransform.position).magnitude > 5f)
            movingPlayer.transform.position = newPosition;
        else
        {
            movingPlayer.SetActive(false);

            if (_currentState == ProductionState.Sleep)
                _currentlyActivePlayer = sleepingPlayer;
            else if (_currentState == ProductionState.Money)
                _currentlyActivePlayer = moneyPlayer;
            else if (_currentState == ProductionState.Energy)
                _currentlyActivePlayer = energyPlayer;

            _currentlyActivePlayer.SetActive(true);
            _isMoving = false;
        }
    }
}
