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
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Deck _deck;

    private GameState _gameState;
    public GameState gameState { get => _gameState; private set => _gameState = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;

        gameState = new GameState();

        _hand = FindObjectOfType<Hand>();
        _board = FindObjectOfType<Board>();
        _player = FindObjectOfType<Player>();
        _deck = new GameObject("Deck", typeof(Deck)).GetComponent<Deck>();

        _board.SetupBoard(levelData.boardData);

        _player.transform.parent = _board.transform;
        _player.transform.position = _board.GetCellPosition(gameState.playerCellId);

        StartGame();
    }

    public void StartGame()
    {
        Card[] cards = _deck.DrawCards(3);
        _hand.SetupInitialHand(cards);
        //Draw 3 cards
        //Offer player to redraw
        //Place the player
    }

    public void StartTurn()
    {
        //TODO : Block hand
        _hand.AddCard(_deck.DrawCard());
        //TODO : Unblock hand
    }

    public void OnCardSelected(Card card)
    {
        gameState.selectedCard = card;
        _board.EnableCellsAroundCell(_gameState.playerCellId);
        //Must highlight the correct cells acording to the type of the card
    }

    public void OnCardDeselected()
    {
        _board.DisableCells();
    }

    public void OnCellSelected(int id)
    {
        _board.DisableCells();
        _board.PlaceCard(gameState.playerCellId, id, gameState.selectedCard);
        //Must play the selected card
        //If room card
        //--> Give card to selected cell
        //--> Move player to cell
        //--> Remaining cards that can be played in this turn -= 1
        //If item card
        //--> ItemCard.boost
        _hand.RemoveCard(_gameState.selectedCard.cardId);
        gameState.selectedCard = null;
    }

    public void AddPlayerMovement(int cellId)
    {
        gameState.AddCellToPlayerMovement(cellId);
    }

    public void OnCardPlaced()
    {
        //Move player
        //TODO: Add ennemies
        int newCell = gameState.GetNextPlayerMovement();
        while (newCell != -1)
        {   
            gameState.playerCellId = newCell;
            _player.MovePlayer(_board.GetCellPosition(newCell));

            newCell = gameState.GetNextPlayerMovement();
        }

        gameState.remainingActions--;
    }

    public void OnTurnEnded()
    {
        _board.MoveBoard();
        //TODO : Check if player is in the lava
        //TODO : Implement more functions to have the animation play nicely
        StartTurn();
    }

}
