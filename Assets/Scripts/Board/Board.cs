using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Dictionary<int,BoardCell> _boardCells;
    private List<int> _enabledCells;

    private BoardData _boardData;

    public void SetupBoard(BoardData boardData, EnnemyData[] ennemies, Ennemy ennemyPrefab)
    {
        _boardData = boardData;

        _boardCells = new Dictionary<int, BoardCell>();
        _enabledCells = new List<int>();

        Sprite cellSprite = boardData.boardCellData.cellSprites.center;

        GameObject cellContainer = new GameObject("CellContainer");
        cellContainer.transform.SetParent(this.transform);

        Vector2 currentPosition = new Vector2(transform.position.x - (cellSprite.bounds.size.x * (boardData.width - 1)) / 2.0f, 0);
        cellContainer.transform.position = currentPosition;

        int currentEnnemyIndex = 0;
        float boardSize = boardData.height * boardData.width;

        for (int height = 0; height < boardData.height; height++)
        {
            for (int width = 0; width < boardData.width; width++)
            {
                currentPosition.x = width * cellSprite.bounds.size.x;
                currentPosition.y = height * cellSprite.bounds.size.y;

                int cellId = width + boardData.width * height;

                //Spawn ennemies randomly
                EnnemyData ennemyData = null;
                if (height >= 2)
                {
                    float currentProbability = (float)(ennemies.Length - currentEnnemyIndex) / (boardSize - cellId);
                    if ((currentEnnemyIndex < ennemies.Length) && (Random.value <= currentProbability))
                    {
                        ennemyData = ennemies[currentEnnemyIndex];
                        currentEnnemyIndex++;
                    }
                }

                //Instantiate cell
                BoardCell newCell = Instantiate(boardData.boardCellPrefab, cellContainer.transform);
                newCell.SetupBoardCell(this, cellId, currentPosition, false, ennemyData, ennemyPrefab);

                _boardCells.Add(cellId, newCell);
            }
        }
        for (int i = 0; i < boardData.width; i++)
        {
            currentPosition.x = i * cellSprite.bounds.size.x;
            currentPosition.y = boardData.height * cellSprite.bounds.size.y;

            int cellId = i + boardData.width * boardData.height;

            //Instantiate last row of cells
            BoardCell newCell = Instantiate(boardData.boardCellPrefab, cellContainer.transform);
            newCell.SetupBoardCell(this, cellId, currentPosition, true, null, null);

            _boardCells.Add(cellId, newCell);
        }

        //TODO: This is very much POG
        _boardCells[0].SetCellRoom();
    }

    public Vector2 GetCellPosition(int cellId)
    {
        return _boardCells[cellId].transform.position;
    }

    public ECellStates GetCellState(int cellId)
    {
        return _boardCells[cellId].GetState();
    }

    public void OnCellSelected(int cellId)
    {
        GameManager.Instance.OnCellSelected(cellId);
    }

    public void AttackCell(int cellId, int damages)
    {
        _boardCells[cellId].AttackCell(damages);
    }

    public void EnableCellsAroundCell(int cellId)
    {
        _enabledCells.Clear();

        int[] neigboursId = {GetValidNeighbourCell(cellId, cellId + _boardData.width, true),
                             GetValidNeighbourCell(cellId, cellId - 1, false),
                             GetValidNeighbourCell(cellId, cellId + 1, false)};

        for (int i = 0; i < 3; i++)
        {
            if (neigboursId[i] >= 0 && _boardCells[neigboursId[i]].IsEmpty())
            {
                _boardCells[neigboursId[i]].EnableCell(true);
                _enabledCells.Add(neigboursId[i]);
            }
        }
    }

    private int GetValidNeighbourCell(int currentCell, int neighbourCell, bool isVertical)
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
                return neighbourCell;           
        }
        return -1;
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
    public void PlaceRoom(int currentCellId, int newCellId, Card card)
    {
        GameManager.Instance.AddPlayerMovement(newCellId);
        _boardCells[newCellId].PlaceRoom(card.cardData);
    }

    public void OnRoomPlaced()
    {
        GameManager.Instance.OnRoomPlaced();
    }

    public void SetCellVisisted(int cellId)
    {
        _boardCells[cellId].SetVisited();
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
