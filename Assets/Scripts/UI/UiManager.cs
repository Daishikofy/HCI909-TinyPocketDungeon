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

    public static UiManager Instance { get => _instance; private set => _instance = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;

        _gameOverPanel.SetActive(false);
        _victoryPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        _victoryPanel.SetActive(true);
    }
}
