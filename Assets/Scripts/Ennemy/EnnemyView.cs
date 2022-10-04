
using UnityEngine;

public class EnnemyView
{
    private Ennemy _controller;
    private SpriteRenderer _renderer;
    public EnnemyView(Ennemy controller, EnnemyModel model, SpriteRenderer pawnRenderer)
    {
        _controller = controller;

        _renderer = pawnRenderer;
        _renderer.sprite = model.data.sprite;
        _renderer.sortingLayerName = "Pawns";
        _renderer.sortingOrder = 1;

        _controller.transform.localPosition = Vector2.zero;
        _controller.transform.localScale = Vector2.one;

        //TODO : Setup life container
    }

    public void OnAttacked()
    {
        //TODO : Damaged animation
        //TODO : Damaged sound effects
    }

    public void OnDefeated()
    {
        _controller.gameObject.SetActive(false);
        //TODO : Death animation
        //TODO : Death sound effects
    }
}
