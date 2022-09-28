using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class BoardCellModel
{
    private int _id = -1;
    private CardData _card = null;
    private bool _isEnabled = false;
    private bool _isSelected = true;

    public UnityEvent onCardChanged;
    public UnityEvent<int> onSelected;

    public BoardCellModel(int id)
    {
        this.id = id;
        onCardChanged = new UnityEvent();
        onSelected = new UnityEvent<int>();
    }

    public int id { get => _id; private set => _id = value; }
    public CardData card 
    { 
        get => _card; 
        set {
            _card = value;
            onCardChanged.Invoke();
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
