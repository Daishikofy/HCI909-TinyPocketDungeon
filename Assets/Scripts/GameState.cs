using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    private Card _selectedCard = null;
    private int _ramainingActions = 1;
    private float _boardMovingVelocity = 1;
    //We could use a ItemTimer which would tell how long the item takes effect and have an ItemEndedAction that we could just call when the Item Timer gets to 0
    //this action would be seted by the item upon use.

    public Card selectedCard { get => _selectedCard; private set => _selectedCard = value;}

    public int remainingActions 
    { 
        get => _ramainingActions; 
        set {
            _ramainingActions = value; 
            if (remainingActions <= 0)
            {
                //TODO: TRIGGER END OF TURN
            }
        } 
    }
}
