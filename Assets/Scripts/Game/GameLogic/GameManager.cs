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
    public Player player { get => _player; private set => _player = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;

        if (GlobalGameManager.Instance != null)
            levelData = GlobalGameManager.Instance.currentLevel;

        gameState = new GameState();

        _hand = FindObjectOfType<Hand>();
        _board = FindObjectOfType<Board>();
        _player = FindObjectOfType<Player>();
        _deck = new GameObject("Deck", typeof(Deck)).GetComponent<Deck>();

        _board.SetupBoard(levelData.boardData, levelData.ennemies, levelData.ennemyPrefab);

        _player.transform.parent = _board.transform;
        _player.transform.position = _board.GetCellPosition(gameState.currentCellId);
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Card[] cards = _deck.DrawCards(3);
        _hand.SetupInitialHand(cards);
        _hand.EnableHand(true);

        gameState.ResetRemaningActions();
        //TODO: Offer player to redraw
    }

    public void StartTurn()
    {
        gameState.ResetRemaningActions();

        _hand.EnableHand(false);
        UiManager.Instance.ShowDice();
    }


    public void DrawCard()
    {
        _deck.DrawCard();    
    }

    public void AddCardToHand(Card card)
    {
        _hand.AddCard(card);

        _hand.EnableHand(true);

        TryToAttackEnnemies(1);      
    }

    public void OnCardSelected(Card card)
    {
        gameState.selectedCard = card;
        //If mouvement card
        if (card.cardData.cardMagic == ECardMagic.PlayerMovement)
            _board.EnableCellsAroundCell(_gameState.currentCellId);
        else //If magic card
            _board.EnableCell(_gameState.currentCellId);
    }

    public void OnCardDeselected()
    {
        _board.DisableCells();
    }

    public void OnCellSelected(int cellId)
    {
        _board.DisableCells();

        _hand.RemoveCard(_gameState.selectedCard.cardId);
        _hand.EnableHand(false);

        if (cellId != gameState.currentCellId)
            _board.PlaceRoom(gameState.currentCellId, cellId);
        else
            UseMagic();
        
        gameState.selectedCard = null;
    }

    private void UseMagic()
    {
        levelData.cardsData.cardMagics[(int)gameState.selectedCard.cardData.cardMagic]();
        TryToEndTurn();
    }
    public void AddPlayerMovement(int cellId)
    {
        gameState.AddCellToPlayerMovement(cellId);
    }

    public void OnRoomPlaced()
    {
        int newCell = gameState.GetNextPlayerMovement();

        _board.SetCellVisisted(gameState.currentCellId);
        gameState.currentCellId = newCell;
        

        if (_board.GetCellState(gameState.currentCellId) == ECellStates.FinalLine)
        {
            UiManager.Instance.ShowVictory();
        }

        _player.MovePlayer(_board.GetCellPosition(gameState.currentCellId));
    }

    public void OnEnnemyAttacked()
    {
        if (gameState.canAttack)
        {
            TryToAttackEnnemies(1);
        }

        TryToEndTurn();
    }

    private bool TryToEndTurn()
    {
        if (gameState.remainingActions <= 0)
        {
            EndTurn();
            return true;
        }
        else if (_hand.IsEmpty())
        {
            EndTurn();
            return true;
        }
        else
        {
            _hand.EnableHand(true);
            return false;
        }
    }

    private bool TryToAttackEnnemies(int actionCost)
    {
        if (_board.GetCellState(gameState.currentCellId) == ECellStates.Blocked && (actionCost == 0 || gameState.remainingActions > 0))
        {
            _player.Attack();

            _board.AttackCell(gameState.currentCellId, _player.attackPower);
            gameState.remainingActions -= actionCost;

            if (gameState.remainingActions <= 0)
            {
                gameState.canAttack = false;
            }
            return true;
        }
        else
        {
            gameState.canAttack = false;
            return false;
        }
    }

    public void GetLoot(List<Card> cards, int money)
    {
        foreach(var card in cards)
        {
            _hand.AddCard(card);
        }
        gameState.currentMoney += money;
    }
    
    public void OnPlayerMoved()
    {
        gameState.remainingActions -= 1;
        if (!TryToAttackEnnemies(0))
        {
            TryToEndTurn();
        }
    }

    public void EndTurn()
    {
        _board.MoveBoard();
        gameState.DecreaseMagicsTimer();

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
