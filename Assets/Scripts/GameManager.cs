using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    public static GameManager Instance { get; private set; }


    public LevelData levelData;

    [SerializeField]
    private Hand _hand;
    [SerializeField]
    private Board _board;

    private GameState _gameState;
    public GameState GameState { get; private set; }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

        _hand = FindObjectOfType<Hand>();
        _board = FindObjectOfType<Board>();
        _board.SetupBoard(levelData.boardData);

        _gameState = new GameState();
    }

    public void OnCardSelected(Card card)
    {
        //Enables the board for selection
        //Must highlight the correct cells acording to the type of the card
    }

    public void OnCellSelected(int id)
    {
        //Must play the selected card
        //If room card
        //--> Give card to selected cell
        //--> Move player to cell
        //--> Remaining cards that can be played in this turn -= 1
        //If item card
        //--> ItemCard.boost
    }

    public void OnTurnEnded()
    {
        //Move board down a row
    }

}
