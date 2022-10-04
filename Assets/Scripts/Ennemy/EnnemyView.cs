
using UnityEngine;

public class EnnemyView
{
    private SpriteRenderer _renderer;
    public EnnemyView(Ennemy controller, EnnemyModel model)
    {
        _renderer = controller.gameObject.AddComponent<SpriteRenderer>();
        _renderer.sprite = model.data.sprite;
        _renderer.sortingLayerName = "Pawns";
        _renderer.sortingOrder = -1;

        controller.transform.localPosition = Vector2.zero;
        controller.transform.localScale = Vector2.one;
    }

    public void OnAttacked()
    {
        //TODO : Damaged animation
        //TODO : Damaged sound effects
    }

    public void OnDefeated()
    {
        _renderer.enabled = false;
        //TODO : Death animation
        //TODO : Death sound effects
    }
}
