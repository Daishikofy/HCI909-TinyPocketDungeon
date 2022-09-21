using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class BoardCellModel
{
    private int _id = -1;
    private Card _card = null;
    private bool _isEnabled = false;

    public UnityEvent OnValueChanged;

    public BoardCellModel(int id)
    {
        this.id = id;
    }

    public int id { get => _id; private set => _id = value; }
    public Card card 
    { 
        get => _card; 
        set {
            _card = value;
            OnValueChanged.Invoke();
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
}
