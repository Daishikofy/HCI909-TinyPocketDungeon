using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellView 
{
    private BoardCell _controller;
    private SpriteRenderer _renderer;

    private Color defaultColor = Color.white;
    private Color hilightColor = new Color(0.5f, 0.5f, 0.5f);
    private Color enabledColor = new Color(0.8f, 0.8f, 0.8f);
    private Color currentStateColor;

    private BoardCellData _cellData;

    public BoardCellView(BoardCell controller, Vector2 position, BoardCellData boardCellData)
    {
        _controller = controller;
        _cellData = boardCellData;

        _controller.gameObject.AddComponent<BoxCollider2D>();

        _renderer = _controller.gameObject.GetComponent<SpriteRenderer>();
        currentStateColor = defaultColor;
        _renderer.color = defaultColor;
        _renderer.sprite = _cellData.cellSprites.empty;

        _controller.transform.localPosition = position;
    }

    public void OnMouseOver()
    {
        if (_controller.model.isEnabled)
        {
            _renderer.color = hilightColor;
        }
    }

    public void OnMouseExit()
    {
        if (_controller.model.isEnabled)
            _renderer.color = currentStateColor;
    }

    public void OnMouseDown()
    {
        _controller.model.isSelected = true;
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

        _renderer.color = currentStateColor;
    }

    public void OnPlaceRoom() 
    {
        //TODO : Animations
        currentStateColor = defaultColor;
        _renderer.color = currentStateColor;

        _renderer.sprite = _cellData.cellSprites.occupied;
        _controller.OnRoomPlaced();
    }

    public void SetCellRoom()
    {
        currentStateColor = defaultColor;
        _renderer.color = currentStateColor;

        _renderer.sprite = _cellData.cellSprites.occupied;
    }
}
