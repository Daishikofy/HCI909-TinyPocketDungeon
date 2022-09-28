using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardCell : MonoBehaviour
{
    private Board _board;

    private BoardCellModel _model;
    private BoardCellView _view;

    private Collider2D _collider;

    public BoardCellModel model { get => _model; private set => _model = value; }
    public BoardCellView view { get => _view; private set => _view = value; }

    public void SetupBoardCell(Board board, int id, Vector2 position)
    {
        gameObject.name = "Cell_" + id;

        _board = board;

        model = new BoardCellModel(id);
        model.onSelected.AddListener(board.OnCellSelected);

        view = new BoardCellView(this, position);
        model.onCardChanged.AddListener(view.OnPlaceCard);

        _collider = GetComponent<Collider2D>();

        EnableCell(false);
    }

    public int GetID()
    {
        return _model.id;
    }

    public bool IsEmpty()
    {
        return model.card == null;
    }

    public void PlaceCard(CardData cardData)
    {
        model.card = cardData;
    }

    public void OnCardPlaced()
    {
        _board.OnCardPlaced();
    }

    public void EnableCell(bool value)
    {
        _collider.enabled = value;
        model.isEnabled = value;
        view.OnEnabled(value);
    }


    private void OnMouseDown()
    {
        view.OnMouseDown();
    }

    private void OnMouseOver()
    {
        view.OnMouseOver();
    }

    private void OnMouseExit()
    {
        view.OnMouseExit();
    }
}
