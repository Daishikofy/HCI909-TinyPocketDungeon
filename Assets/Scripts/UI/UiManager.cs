using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    static private UiManager _instance;

    [SerializeField]
    GameObject _gameOverPanel;
    [SerializeField]
    GameObject _victoryPanel;
    [SerializeField]
    GamePanel _gamePanel;
    [SerializeField]
    GameObject _pausePanel;
    [SerializeField]
    Dice _dice;

    public static UiManager Instance { get => _instance; private set => _instance = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;

        _gameOverPanel.SetActive(false);
        _victoryPanel.SetActive(false);
        _pausePanel.SetActive(false);

        _gamePanel.gameObject.SetActive(true);

        _dice.gameObject.SetActive(false);
        _dice.SetupDice(OnDiceRolled);
    }

    public void ShowGameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        _victoryPanel.SetActive(true);
    }

    public void PauseGame(bool value)
    {
        _pausePanel.SetActive(value);
        _gamePanel.gameObject.SetActive(!value);
    }

    public void UpdateRemainingMoves(int moves)
    {
        _gamePanel.UpdateRemainingMoves(moves);
    }

    public void ShowDice()
    {
        _dice.gameObject.SetActive(true);
    }

    public void OnDiceRolled()
    {
        GameManager.Instance.StartTurnPartTwo();
    }

    public void DrawCard(CardData data, UnityAction callback)
    {
        //TODO : Show card screen
        //TODO : Only call the callback after card screen animation stoped
        callback();
    }
}
