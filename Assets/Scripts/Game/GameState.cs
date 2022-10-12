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

    private Dictionary<ECardMagic, int> _magicsTimer;

    public bool canAttack = true;
    //We could use a ItemTimer which would tell how long the item takes effect and have an ItemEndedAction that we could just call when the Item Timer gets to 0
    //this action would be seted by the item upon use.

    public GameState ()
    {
        _playerMovementQueue = new Queue<int>();
        _magicsTimer = new Dictionary<ECardMagic, int>();

        _magicsTimer.Add(ECardMagic.PegasusBoots, 0);
        _magicsTimer.Add(ECardMagic.Hourglass, 0);
        _magicsTimer.Add(ECardMagic.Sword, 0);
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

    public void SetMaxActions(int maxActions, int turns)
    {
        _maxActions = maxActions;
        _magicsTimer[ECardMagic.PegasusBoots] += turns;
    }
    private void ResetMaxActions()
    {
        _maxActions = 1;
    }

    public void SetBoardVelocity(float velocity, int turns)
    {
        boardMovingVelocity = velocity;
        _magicsTimer[ECardMagic.Hourglass] += turns;
    }
    private void ResetBoardVelocity()
    {
        boardMovingVelocity = 1;
    }

    public void SetPlayerPower(int power, int turns)
    {
        GameManager.Instance.player.AddToAttackPower(power);
        _magicsTimer[ECardMagic.Sword] += turns;
    }
    public void ResetPlayerPower()
    {
        GameManager.Instance.player.AddToAttackPower(1);
    }

        public void DecreaseMagicsTimer()
    {
        foreach (var timer in _magicsTimer)
        {
            int remainingTime = timer.Value;
            if (remainingTime > 0)
            {
                remainingTime = timer.Value - 1;
                if (timer.Value < 1)
                {
                    switch (timer.Key)
                    {
                        case ECardMagic.PlayerMovement:
                            break;
                        case ECardMagic.Sword:
                            ResetPlayerPower();
                            break;
                        case ECardMagic.Hourglass:
                            ResetBoardVelocity();
                            break;
                        case ECardMagic.PegasusBoots:
                            ResetMaxActions();
                            break;
                        default:
                            break;
                    }
                }
            }
            _magicsTimer[timer.Key] = remainingTime;
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
