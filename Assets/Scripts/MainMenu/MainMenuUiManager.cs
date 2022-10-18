using UnityEngine;
using TMPro;

public class MainMenuUiManager : MonoBehaviour
{
    [SerializeField]
    LevelsPanel _levelsPanel;

    [SerializeField]
    TextMeshProUGUI _scoreText;


    // Start is called before the first frame update
    void Awake()
    {
        _levelsPanel.gameObject.SetActive(true);
    }

    private void Start()
    {
        _scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void ShowLevelMenu(bool value)
    {
        _levelsPanel.gameObject.SetActive(true);
    }
}
