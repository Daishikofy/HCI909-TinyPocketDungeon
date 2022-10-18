using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    private int _currentScore = 0;
    public int currentScore { get => _currentScore; set { _currentScore = value; UiManager.Instance.UpdateScore(_currentScore); } }

    public float boardMovingVelocity = 1f;
    public int currentCellId = 0;

    private int _maxActions = 1;
    public int maxActions { get => _maxActions; set => _maxActions = value; }

    private Queue<int> _playerMovementQueue;
    private Card _selectedCard = null;
    private int _ramainingActions = 1;

    private int[] _magicsTimer = {0, 0, 0, 0};

    public bool canAttack = true;
    //We could use a ItemTimer which would tell how long the item takes effect and have an ItemEndedAction that we could just call when the Item Timer gets to 0
    //this action would be seted by the item upon use.

    public GameState ()
    {
        _playerMovementQueue = new Queue<int>();
    }

    public Card selectedCard { get => _selectedCard; set => _selectedCard = value;}

    public int remainingActions 
    { 
        get => _ramainingActions; 
        set {
            _ramainingActions = value;
            UiManager.Instance.UpdateRemainingMoves(remainingActions);
        } 
    }

    public void SetMagicTimer(int index, int value)
    {
        _magicsTimer[index] = value;
    }

    public void DecreaseMagicsTimer()
    {
        for (int i = 1; i < _magicsTimer.Length; i++)
        {
            if (_magicsTimer[i] > 0)
            {
                _magicsTimer[i] -= 1;
                if (_magicsTimer[i] < 1)
                {
                    //If the timer for the magic of index i gets to 0, call the function
                    //to remove the magic's effect.
                    GlobalGameState.Instance.config.cardsData.disableCardMagic[i]();
                }
            }
        }
    }

    public void ResetRemaningActions()
    {
        remainingActions = _maxActions;
    }

    public void AddCellToPlayerMovement(int cellId)
    {
        _playerMovementQueue.Enqueue(cellId);
    }

    public int GetNextPlayerMovement()
    {
        if (_playerMovementQueue.Count > 0)
            return _playerMovementQueue.Dequeue();
        else
            return -1;
    }

    public void Save()
    {
        int previousScore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", previousScore + currentScore);
    }
}
