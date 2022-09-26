using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    List<BoardCell> boardCells;

    private GameManager _gameManager;

    public void SetupBoard(GameManager manager, BoardData boardData)
    {
        _gameManager = manager;

        boardCells = new List<BoardCell>();
        Sprite cellSprite = boardData.boardCellData.cellSprites.center;

        Vector2 currentPosition = new Vector2(transform.position.x - (cellSprite.bounds.size.x * boardData.width) / 2.0f, 0);
        transform.position = currentPosition;

        for (int height = 0; height < boardData.height; height++)
        {
            for (int width = 0; width < boardData.width; width++)
            {
                currentPosition.x = width * cellSprite.bounds.size.x;
                currentPosition.y = height * cellSprite.bounds.size.y;

                int cellId = boardData.width + boardData.width * boardData.height;

                BoardCell newCell = Instantiate(boardData.boardCellPrefab, this.transform);
                newCell.SetupBoardCell(cellId, currentPosition);

                boardCells.Add(newCell);
            }
        }
    }

    public void OnCellSelected(int id)
    {
        _gameManager.OnCellSelected(id);
    }

    //Place a card on the board
    public void PlaceCard()
    {

    }

    //Move the board down
    public void MoveBoard()
    {

    }
}
