using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellView 
{
    private BoardCell controller;
    private SpriteRenderer renderer;
    private Collider collider;

    private Color defaultColor = Color.cyan;
    private Color hilightColor = Color.red;
    private Color enabledColor = Color.white;
    public BoardCellView(BoardCell controller, Vector2 position)
    {
        this.controller = controller;

        controller.gameObject.AddComponent<BoxCollider2D>();

        renderer = controller.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = defaultColor;

        controller.transform.localPosition = position;
    }

    public void OnMouseOver()
    {
        renderer.color = hilightColor;
    }

    public void OnMouseExit()
    {
        renderer.color = defaultColor;
    }

    public void OnEnabled(bool value)
    {
        collider.enabled = value;
        if (value)
        {
            renderer.color = enabledColor;
        }
        else
        {
            renderer.color = defaultColor;
        }
    }
}
