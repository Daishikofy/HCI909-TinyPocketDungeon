using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

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
}
