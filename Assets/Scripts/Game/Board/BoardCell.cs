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

    [SerializeField]
    private Transform _ennemySpawnPoint;

    public BoardCellModel model { get => _model; private set => _model = value; }
    public BoardCellView view { get => _view; private set => _view = value; }

    public void SetupBoardCell(Board board, int id, Vector2 position, BoardCellData boardCellData,bool isFinishLine, EnnemyData ennemyData, Ennemy ennemyPrefab)
    {
        gameObject.name = "Cell_" + id;

        _board = board;

        model = new BoardCellModel(id, isFinishLine);
        model.onSelected.AddListener(board.OnCellSelected);

        view = new BoardCellView(this, position, boardCellData);

        _collider = GetComponent<Collider2D>();

        EnableCell(false);

        if (ennemyData != null)
        {
            //Instanciate new ennemy
            model.ennemy = Instantiate(ennemyPrefab, _ennemySpawnPoint);
            model.ennemy.SetupEnnemy(ennemyData, OnEnnemyDefeated);
            SetCellRoom();
        }
    }

    public void SetCellRoom()
    {
        view.SetCellRoom();
    }

    public int GetID()
    {
        return _model.id;
    }

    public bool IsWalkable()
    {
        return model.cellState == ECellStates.Empty || model.cellState == ECellStates.Blocked || model.cellState == ECellStates.FinalLine;
    }


    public void PlaceRoom()
    {
        if(model.cellState == ECellStates.Blocked)
        {
            //ROOM HAS ENNEMY
            //Could trigger a special vfx or sfx here
        }
        else
        {
            model.cellState = ECellStates.Room;
        }

        view.OnPlaceRoom();
    }

    public void OnRoomPlaced()
    {
        _board.OnRoomPlaced();
    }

    public void SetVisited()
    {
        if (model.cellState != ECellStates.Blocked)
            model.cellState = ECellStates.Connected;
    }

    public void EnableCell(bool value)
    {
        _collider.enabled = value;
        model.isEnabled = value;
        view.OnEnabled(value);
    }

    public void AttackCell(int damages)
    {
        model.ennemy.Attacked(damages);
    }

    public ECellStates GetState()
    {
        return model.cellState;
    }

    private void OnEnnemyDefeated()
    {
        model.cellState = ECellStates.Connected;
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
