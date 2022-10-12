using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    Button _pauseButton;

    [SerializeField]
    Button _skipTurn;

    [SerializeField]
    TextMeshProUGUI _pointsText;

    [SerializeField]
    TextMeshProUGUI _remainingMoves;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(PauseButtonClicked);
        _skipTurn.onClick.AddListener(SkipTurnButtonClicked);
    }

    private void PauseButtonClicked()
    {
        UiManager.Instance.PauseGame(true);
    }

    public void UpdatePoints(int points)
    {
        string newText = "";
        if (points >= 1000)
        {
            newText = 999.ToString();
        }
        else if (points >= 100)
        {
            newText = points.ToString();
        }
        else if (points >= 10)
        {
            newText = "0" + points.ToString();
        }
        else
        {
            newText = "00" + points.ToString();
        }

        _pointsText.text = newText;
    }

    public void UpdateRemainingMoves(int moves)
    {
        _remainingMoves.text = moves.ToString();
    }

    private void SkipTurnButtonClicked()
    {
        GameManager.Instance.EndTurn();
    }
}
