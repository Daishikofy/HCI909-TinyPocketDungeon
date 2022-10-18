
using UnityEngine;

public class EnnemyView
{
    private Ennemy _controller;
    private SpriteRenderer _thumbnailRenderer;
    private SpriteRenderer[] _lifePoints;
    private Animator _animator;
    public EnnemyView(Ennemy controller, EnnemyModel model, SpriteRenderer pawnRenderer, SpriteRenderer[] lifePoints)
    {
        _controller = controller;

        _thumbnailRenderer = pawnRenderer;
        _thumbnailRenderer.sprite = model.data.sprite;
        _thumbnailRenderer.sortingLayerName = "Pawns";
        _thumbnailRenderer.sortingOrder = 1;

        _lifePoints = lifePoints;

        //Hide all life points above the current number of HP
        for(int i = _controller._model.currentLifePoints; i < 3; i++)
        {
            _lifePoints[i].sprite = null;
        }

        _controller.transform.localPosition = Vector2.zero;
        _controller.transform.localScale = Vector2.one;

        _animator = _controller.GetComponent<Animator>();
    }

    public void OnAttacked()
    {
        _lifePoints[_controller._model.currentLifePoints].sprite = null;
        _animator.SetTrigger("Attacked");
        //TODO : Damaged animation
        //TODO : Damaged sound effects
    }

    public void OnDefeated()
    {
        _animator.SetTrigger("Defeated");
        //TODO : Death animation
        //TODO : Death sound effects
        _controller.GetLoot();
    }
}
