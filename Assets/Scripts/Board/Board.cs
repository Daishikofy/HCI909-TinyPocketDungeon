using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<int,BoardCell> _boardCells;
    private List<int> _enabledCells;

    private GameManager _gameManager;
    private BoardData _boardData;

    public void SetupBoard(GameManager manager, BoardData boardData)
    {
        _gameManager = manager;
        _boardData = boardData;

        _boardCells = new Dictionary<int, BoardCell>();
        _enabledCells = new List<int>();

        Sprite cellSprite = boardData.boardCellData.cellSprites.center;

        Vector2 currentPosition = new Vector2(transform.position.x - (cellSprite.bounds.size.x * boardData.width) / 2.0f, 0);
        transform.position = currentPosition;

        for (int height = 0; height < boardData.height; height++)
        {
            for (int width = 0; width < boardData.width; width++)
            {
                currentPosition.x = width * cellSprite.bounds.size.x;
                currentPosition.y = height * cellSprite.bounds.size.y;

                int cellId = width + boardData.width * height;

                BoardCell newCell = Instantiate(boardData.boardCellPrefab, this.transform);
                newCell.SetupBoardCell(cellId, currentPosition);

                _boardCells.Add(cellId, newCell);
            }
        }
    }

    public void OnCellSelected(int id)
    {
        _gameManager.OnCellSelected(id);
    }

    public void EnableCellsAroundCell(int cellId)
    {
        _enabledCells.Clear();
        Vector2 cellPosition = CellIdToPosition(cellId);
        int neighbourCell = cellId - 1;

        if(_boardCells.ContainsKey(neighbourCell))
        {
            if(CellIdToPosition(cellId).x == cellPosition.x)
            {
                _boardCells[neighbourCell].EnableCell(true);
                _enabledCells.Add(neighbourCell);
            }
        }

        neighbourCell = cellId + 1;
        if (_boardCells.ContainsKey(neighbourCell))
        {
            if (CellIdToPosition(cellId).x == cellPosition.x)
            {
                _boardCells[neighbourCell].EnableCell(true);
                _enabledCells.Add(neighbourCell);
            }
        }

        neighbourCell = cellId + _boardData.width;
        if (_boardCells.ContainsKey(neighbourCell))
        {
            if (CellIdToPosition(cellId).x == cellPosition.x)
            {
                _boardCells[neighbourCell].EnableCell(true);
                _enabledCells.Add(neighbourCell);
            }
        }
    }

    public void DisableCells()
    {
        foreach (var id in _enabledCells)
        {
            _boardCells[id].EnableCell(false);
        }
        _enabledCells.Clear();
    }

    //Place a card on the board
    public void PlaceCard()
    {

    }

    //Move the board down
    public void MoveBoard()
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= GameManager.Instance.GameState.boardMovingVelocity * _boardData.boardCellData.cellSprites.center.bounds.size.y;
        transform.position = newPosition;
    }

    private Vector2 CellIdToPosition(int id)
    {
        int x = id % _boardData.width;
        if (x == 0)
            x = _boardData.width;
        else
            x -= 1;
        int y = id / _boardData.width;
        return new Vector2(x, y);
    }

}
