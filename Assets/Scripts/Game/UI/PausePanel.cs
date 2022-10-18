using UnityEngine;
using UnityEngine.UI;


public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _homeButton;

    [SerializeField]
    private Button _replayButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(PlayButtonClicked);
        _homeButton.onClick.AddListener(HomeButtonClicked);
        _replayButton.onClick.AddListener(ReplayButtonClicked);
    }

    private void ReplayButtonClicked()
    {
        //Using unity's scene manager to reload the game at it's original state
        GlobalGameManager.Instance.LoadLevel(GlobalGameManager.Instance.currentLevel);
    }

    private void HomeButtonClicked()
    {
        GlobalGameManager.Instance.LoadMainMenu();
    }

    private void PlayButtonClicked()
    {
        UiManager.Instance.PauseGame(false);
    }
}
