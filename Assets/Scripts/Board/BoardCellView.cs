using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellView 
{
    private BoardCell controller;
    private SpriteRenderer renderer;

    private Color defaultColor = new Color(0.7f, 0.7f, 0.0f);
    private Color hilightColor = Color.red;
    private Color enabledColor = Color.white;
    private Color placedColor = Color.black;

    private Color currentStateColor;
    public BoardCellView(BoardCell controller, Vector2 position)
    {
        this.controller = controller;

        controller.gameObject.AddComponent<BoxCollider2D>();

        renderer = controller.gameObject.GetComponent<SpriteRenderer>();
        currentStateColor = defaultColor;

        controller.transform.localPosition = position;
    }

    public void OnMouseOver()
    {
        if (controller.model.isEnabled)
        {
            renderer.color = hilightColor;
        }
    }

    public void OnMouseExit()
    {
        if (controller.model.isEnabled)
            renderer.color = currentStateColor;
    }

    public void OnMouseDown()
    {
        controller.model.isSelected = true;
    }

    public void OnEnabled(bool value)
    {
        if (value)
        {
            currentStateColor = enabledColor;
        }
        else
        {
            currentStateColor = defaultColor;
        }

        renderer.color = currentStateColor;
    }

    public void OnPlaceRoom() 
    {
        //TODO : Animations
        currentStateColor = placedColor;
        renderer.color = currentStateColor;
        controller.OnRoomPlaced();
    }

    public void SetCellRoom()
    {
        currentStateColor = placedColor;
        renderer.color = currentStateColor;
    }
}
