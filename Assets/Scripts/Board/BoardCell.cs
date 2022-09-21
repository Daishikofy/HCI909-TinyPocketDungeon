using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private Board board;

    private BoardCellModel _model;
    private BoardCellView _view;

    public BoardCellModel model { get; private set; }
    public BoardCellView view { get; private set; }

    public void SetupBoardCell(int id, Vector2 position)
    {
        model = new BoardCellModel(id);
        view = new BoardCellView(this, position);
    }

    public void EnableCell(bool value)
    {
        _model.isEnabled = value;
        _view.OnEnabled(value);
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
