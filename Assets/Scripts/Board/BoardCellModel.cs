using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;



public class BoardCellModel
{
    private int _id = -1;
    private ECellStates _cellState = ECellStates.Empty;
    private bool _isEnabled = false;
    private bool _isSelected = true;
    private Ennemy _ennemy;

    public UnityEvent onStateChanged;
    public UnityEvent<int> onSelected;

    public BoardCellModel(int id, bool isFinishLine)
    {
        this.id = id;
        if (isFinishLine)
        {
            _cellState = ECellStates.FinalLine;
        }
        onStateChanged = new UnityEvent();
        onSelected = new UnityEvent<int>();
    }

    public int id { get => _id; private set => _id = value; }
    public Ennemy ennemy 
    { 
        get => _ennemy;
        set
        {
            _ennemy = value;
            if(_ennemy != null)
            {
                cellState = ECellStates.Blocked;
            }
        }
    }

    public ECellStates cellState 
    { 
        get => _cellState; 
        set {
            if (_cellState == ECellStates.FinalLine) return;
            _cellState = value;
            onStateChanged.Invoke();
        }
    }

    public bool isEnabled 
    { 
        get => _isEnabled; 
        set
        {
            if (value != _isEnabled)
            {
                _isEnabled = value;
                
            }
        }
    }

    public bool isSelected
    {
        get => _isSelected;
        set {
            if (value)
            {
                _isSelected = value;
                onSelected.Invoke(_id);
            }
        }
    }
}
