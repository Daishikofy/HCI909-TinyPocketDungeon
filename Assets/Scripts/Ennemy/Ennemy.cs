using UnityEngine;
using UnityEngine.Events;

public class Ennemy : MonoBehaviour
{
    private EnnemyModel _model;
    private EnnemyView _view;
    public void SetupEnnemy(EnnemyData data, UnityAction onDefeatedCallback)
    {
        _model = new EnnemyModel(data);
        _model.onDefeated.AddListener(onDefeatedCallback);
        _model.onDefeated.AddListener(OnDefeated);
        _view = new EnnemyView(this, _model);
    }

    private void OnDefeated()
    {
        _view.OnDefeated();
        //TODO : The player can continue it's way
    }

    public void OnAttacked(int damages)
    {
        _view.OnAttacked();
        _model.currentLifePoints -= damages;
    }
}
