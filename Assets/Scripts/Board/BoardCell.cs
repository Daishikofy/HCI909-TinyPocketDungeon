using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private Board board;

    private BoardCellModel _model;
    private BoardCellView _view;

    public BoardCellModel model { get => _model; private set => _model = value; }
    public BoardCellView view { get => _view; private set => _view = value; }

    public void SetupBoardCell(int id, Vector2 position)
    {
        model = new BoardCellModel(id);
        view = new BoardCellView(this, position);

        EnableCell(false);
    }

    public int GetID()
    {
        return _model.id;
    }

    public void EnableCell(bool value)
    {
        model.isEnabled = value;
        view.OnEnabled(value);
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
