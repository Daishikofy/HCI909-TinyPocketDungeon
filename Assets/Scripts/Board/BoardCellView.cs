using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellView 
{
    private BoardCell controller;
    private SpriteRenderer renderer;

    private Color defaultColor = Color.cyan;
    private Color hilightColor = Color.red;
    private Color enabledColor = Color.white;
    public BoardCellView(BoardCell controller, Vector2 position)
    {
        this.controller = controller;

        controller.gameObject.AddComponent<BoxCollider2D>();

        renderer = controller.gameObject.GetComponent<SpriteRenderer>();

        controller.transform.localPosition = position;
    }

    public void OnMouseOver()
    {
        if (controller.model.isEnabled)
            renderer.color = hilightColor;
    }

    public void OnMouseExit()
    {
        if (controller.model.isEnabled)
            renderer.color = enabledColor;
    }

    public void OnMouseDown()
    {
        controller.model.isSelected = true;
    }

    public void OnEnabled(bool value)
    {
        if (value)
        {
            renderer.color = enabledColor;
        }
        else
        {
            renderer.color = defaultColor;
        }
    }

    public void OnPlaceCard() 
    {
       Debug.Log("Place card : " + controller.model.card.cardData.cardName);
        controller.OnCardPlaced();
    }
}
