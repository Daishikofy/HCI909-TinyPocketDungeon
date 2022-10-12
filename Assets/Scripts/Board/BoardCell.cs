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

    public void SetupBoardCell(Board board, int id, Vector2 position, bool isFinishLine, EnnemyData ennemyData, Ennemy ennemyPrefab)
    {
        gameObject.name = "Cell_" + id;

        _board = board;

        model = new BoardCellModel(id, isFinishLine);
        model.onSelected.AddListener(board.OnCellSelected);

        view = new BoardCellView(this, position);

        _collider = GetComponent<Collider2D>();

        EnableCell(false);

        if (ennemyData != null)
        {
            //Instanciate new ennemy
            model.ennemy = Instantiate(ennemyPrefab, _ennemySpawnPoint);
            model.ennemy.SetupEnnemy(ennemyData, OnEnnemyDefeated);
            //TODO: Maybe connect to controller directly?
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

    public bool IsEmpty()
    {
        //TODO: Rename function to reflect the fact that not only empty cells can be moved on
        return model.cellState == ECellStates.Empty || model.cellState == ECellStates.Blocked;
    }


    public void PlaceRoom(CardData cardData)
    {
        //TODO: The use of cardData is a bit irrelevant for now. Look at the 01/10/2022 note about why it is like this before removing it. 
        model.cellState = ECellStates.Room;
        view.OnPlaceRoom();
    }

    public void OnRoomPlaced()
    {
        _board.OnRoomPlaced();
    }

    public void SetVisited()
    {
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
        model.ennemy.OnAttacked(damages);
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
