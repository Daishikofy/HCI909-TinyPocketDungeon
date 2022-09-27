using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _instance;
    public static GameManager Instance { get => _instance; private set => _instance = value; }


    public LevelData levelData;

    [SerializeField]
    private Hand _hand;
    [SerializeField]
    private Board _board;

    private GameState _gameState;
    public GameState GameState { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;

        _hand = FindObjectOfType<Hand>();
        _board = FindObjectOfType<Board>();
        _board.SetupBoard(this, levelData.boardData);

        _gameState = new GameState();
    }

    public void StartGame()
    {
        //Draw 3 cards
        //Offer player to redraw
        //Place the player
    }

    public void StartTurn()
    {
        //Draw card
    }

    public void OnCardSelected(Card card)
    {
        Debug.Log("GameInstance: On Card Selected");
        _gameState.selectedCard = card;
        _board.EnableCellsAroundCell(_gameState.playerCellId);
        //Enables the board for selection around the player
        //Must highlight the correct cells acording to the type of the card
    }

    public void OnCardDeselected()
    {
        _board.DisableCells();
    }

    public void OnCellSelected(int id)
    {
        Debug.Log("Cell " + id + " was selected.");
        //Must play the selected card
        //If room card
        //--> Give card to selected cell
        //--> Move player to cell
        //--> Remaining cards that can be played in this turn -= 1
        //If item card
        //--> ItemCard.boost
        _hand.RemoveCard(_gameState.selectedCard.GetInstanceID());
    }

    public void OnTurnEnded()
    {
        //Move board down a row
    }

}
