using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<int,BoardCell> _boardCells;
    private List<int> _enabledCells;

    private BoardData _boardData;

    public void SetupBoard(BoardData boardData)
    {
        _boardData = boardData;

        _boardCells = new Dictionary<int, BoardCell>();
        _enabledCells = new List<int>();

        Sprite cellSprite = boardData.boardCellData.cellSprites.center;

        GameObject cellContainer = new GameObject("CellContainer");
        cellContainer.transform.SetParent(this.transform);

        Vector2 currentPosition = new Vector2(transform.position.x - (cellSprite.bounds.size.x * (boardData.width - 1)) / 2.0f, 0);
        cellContainer.transform.position = currentPosition;

        for (int height = 0; height < boardData.height; height++)
        {
            for (int width = 0; width < boardData.width; width++)
            {
                currentPosition.x = width * cellSprite.bounds.size.x;
                currentPosition.y = height * cellSprite.bounds.size.y;

                int cellId = width + boardData.width * height;
                Vector2 position = CellIdToPosition(cellId);
                //print("Id: " + cellId + " - Position : (" + position.x + ", " + position.y + ")");

                BoardCell newCell = Instantiate(boardData.boardCellPrefab, cellContainer.transform);
                newCell.SetupBoardCell(this, cellId, currentPosition);

                _boardCells.Add(cellId, newCell);
            }
        }
    }

    public Vector2 GetCellPosition(int cellId)
    {
        return _boardCells[cellId].transform.position;
    }

    public void OnCellSelected(int id)
    {
        GameManager.Instance.OnCellSelected(id);
    }

    public void EnableCellsAroundCell(int cellId)
    {
        _enabledCells.Clear();

        EnableNeighbourCell(cellId, cellId - 1, false);
        EnableNeighbourCell(cellId, cellId + 1, false);
        EnableNeighbourCell(cellId, cellId + _boardData.width, true);

    }

    private void EnableNeighbourCell(int currentCell, int neighbourCell, bool isVertical)
    {
        Vector2 cellPosition = CellIdToPosition(currentCell);
        if (_boardCells.ContainsKey(neighbourCell))
        {
            bool isValid = false;
            Vector2 neighbourPosition = CellIdToPosition(neighbourCell);
            if (isVertical)
                isValid = neighbourPosition.x == cellPosition.x;
            else
                isValid = neighbourPosition.y == cellPosition.y;

            if (isValid)
            {
                if (_boardCells[neighbourCell].IsEmpty())
                {
                    _boardCells[neighbourCell].EnableCell(true);
                    _enabledCells.Add(neighbourCell);
                }
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
    public void PlaceCard(int currentCellId, int newCellId, Card card)
    {
        GameManager.Instance.AddPlayerMovement(newCellId);

        //if newCellId - currentCellId = 1 : ->
        //if newCellId - currentCellId = -1 : <-
        //if newCellId - currentCellId > 1 : î

        //Check for other cells around
        //If a cell is not connected, connects it
        //GameManager.Instance.AddPlayerMovement(otherCell);

        //PlaceCard will trigger the player movement. I should only be executed after all player movment have been registred.
        _boardCells[newCellId].PlaceCard(card);
    }

    public void OnCardPlaced()
    {
        GameManager.Instance.OnCardPlaced();
    }

    //Move the board down
    public void MoveBoard()
    {
        Vector2 newPosition = transform.position;
        newPosition.y -= GameManager.Instance.gameState.boardMovingVelocity * _boardData.boardCellData.cellSprites.center.bounds.size.y;
        transform.position = newPosition;
    }

    private Vector2 CellIdToPosition(int id)
    {
        int x = id % _boardData.width;
        int y = id / _boardData.width;
        return new Vector2(x, y);
    }

}
