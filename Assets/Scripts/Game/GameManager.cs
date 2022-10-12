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

        _board.SetupBoard(levelData.boardData, levelData.ennemies, levelData.ennemyPrefab);

        _player.transform.parent = _board.transform;
        _player.transform.position = _board.GetCellPosition(gameState.currentCellId);

        StartGame();
    }

    public void StartGame()
    {
        Card[] cards = _deck.DrawCards(3);
        _hand.SetupInitialHand(cards);
        //TODO: Offer player to redraw
    }

    public void StartTurn()
    {
        //TODO : remainingActions actually depends on player state so Cretae a function in gamestate >> ResetRemaininfActions() 
        gameState.remainingActions = 1;

        _hand.EnableHand(false);
        UiManager.Instance.ShowDice();
    }



    public void StartTurnPartTwo()
    {
        _deck.DrawCard();    
    }

    public void AddCardToHand(Card card)
    {
        _hand.AddCard(card);

        _hand.EnableHand(true);

        //TODO: REMOVE THE FACT THAT YOU CANNOT PLAY ON BLOCKED CELL
        if (_board.GetCellState(gameState.currentCellId) == ECellStates.Blocked)
            ExecuteTurnAction();
    }

    public void OnCardSelected(Card card)
    {
        gameState.selectedCard = card;
        //IF MAGIC CARD
        ////ENABLE PLAYER
        //IF ROOM CARD
        _board.EnableCellsAroundCell(_gameState.currentCellId);
        //Must highlight the correct cells acording to the type of the card
    }

    public void OnCardDeselected()
    {
        _board.DisableCells();
    }

    public void OnCellSelected(int id)
    {
        _board.DisableCells();

        _hand.RemoveCard(_gameState.selectedCard.cardId);
        _board.PlaceRoom(gameState.currentCellId, id, gameState.selectedCard);
        //Must play the selected card
        //If room card
        //--> Give card to selected cell
        //--> Move player to cell
        //--> Remaining cards that can be played in this turn -= 1
        //If item card
        //--> ItemCard.boost
        
        gameState.selectedCard = null;
    }

    public void AddPlayerMovement(int cellId)
    {
        gameState.AddCellToPlayerMovement(cellId);
    }

    public void OnRoomPlaced()
    {
        /*
        while (gameState.remainingActions > 0 )
        {      
            ExecuteTurnAction();
            gameState.remainingActions -= 1;
            Debug.Log("remaining actions: " + gameState.remainingActions);
        }
        OnTurnEnded();*/
        ExecuteTurnAction();
    }

    public void ExecuteTurnAction()
    {
        while (gameState.remainingActions > 0)
        {
            if (_board.GetCellState(gameState.currentCellId) == ECellStates.Blocked)
            {
                _board.AttackCell(gameState.currentCellId, _player.attackPower);
            }
            else
            {
                //If Card == Mouvement ->
                int newCell = gameState.GetNextPlayerMovement();
                while (newCell != -1 && (_board.GetCellState(gameState.currentCellId) != ECellStates.Blocked))
                {
                    _board.SetCellVisisted(gameState.currentCellId);

                    gameState.currentCellId = newCell;
                    _player.MovePlayer(_board.GetCellPosition(gameState.currentCellId));

                    if (_board.GetCellState(gameState.currentCellId) == ECellStates.FinalLine)
                    {
                        UiManager.Instance.ShowVictory();
                        break;
                    }

                    if (_board.GetCellState(gameState.currentCellId) == ECellStates.Blocked)
                    {
                        _board.AttackCell(gameState.currentCellId, _player.attackPower);
                    }

                    newCell = gameState.GetNextPlayerMovement();
                }
            }

            gameState.remainingActions -= 1;
        }
        OnTurnEnded();
        //Debug.Log("END Execute turn action");
    }
    
    public void OnPlayerMoved()
    {
        //ExecuteTurnAction();
    }

    public void OnTurnEnded()
    {
        _board.MoveBoard();
        if(_player.transform.position.y <= levelData.gameOverHeight)
        {
            GameOver();
        }
        else
        {
            StartTurn();
        }
    }

    private void GameOver()
    {
        UiManager.Instance.ShowGameOver();
    }

}
