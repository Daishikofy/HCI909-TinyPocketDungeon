using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    private void HomeButtonClicked()
    {
        throw new System.NotImplementedException();
    }

    private void PlayButtonClicked()
    {
        UiManager.Instance.PauseGame(false);
    }
}
