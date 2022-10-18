using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField]
    private Animation _animation;
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private Button _replayButton;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _homeButton.onClick.AddListener(OnHomeButtonClicked);
        _replayButton.onClick.AddListener(OnReplayClicked);
    }
    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        _animation.Play();
    }

    private void OnHomeButtonClicked()
    {
        GlobalGameManager.Instance.LoadMainMenu();
    }

    private void OnReplayClicked()
    {
        GlobalGameManager.Instance.LoadLevel(GlobalGameManager.Instance.currentLevel);
    }
}
