using UnityEngine.Events;
public class EnnemyModel 
{
    private EnnemyData _data;
    private int _currentLifePoints;

    public UnityEvent onDefeated;
    public UnityEvent onAttacked;

    #region GETTERS/SETTERS
    public EnnemyData data { get => _data; private set => _data = value; }
    public int currentLifePoints 
    { 
        get => _currentLifePoints; 

        set { 
            _currentLifePoints = value; 

            if (_currentLifePoints <= 0) 
            { 
                onDefeated.Invoke(); 
            } 
            else
            {
                onAttacked.Invoke();
            }
        } 
    }
    #endregion

    public EnnemyModel(EnnemyData data)
    {
        this.data = data;
        _currentLifePoints = _data.maxLifePoints;

        onDefeated = new UnityEvent();
        onAttacked = new UnityEvent();
    }
}
