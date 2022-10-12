 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    public float boardMovingVelocity = 1f;
    public int currentCellId = 0;

    private int _maxActions = 1;

    private Queue<int> _playerMovementQueue;
    private Card _selectedCard = null;
    private int _ramainingActions = 1;

    public bool canAttack = true;
    //We could use a ItemTimer which would tell how long the item takes effect and have an ItemEndedAction that we could just call when the Item Timer gets to 0
    //this action would be seted by the item upon use.

    public GameState ()
    {
        _playerMovementQueue = new Queue<int>();
    }

    public Card selectedCard { get => _selectedCard; set => _selectedCard = value;}

    public void AddToMaxActions(int actionsBoost)
    {
        _maxActions += actionsBoost;
    }
    public void SetBoardVelocity(float velocity)
    {
        boardMovingVelocity = velocity;
    }
    public int remainingActions 
    { 
        get => _ramainingActions; 
        set {
            _ramainingActions = value;
            UiManager.Instance.UpdateRemainingMoves(remainingActions);

            if (remainingActions <= 0)
            {
                //GameManager.Instance.OnTurnEnded();
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
}
