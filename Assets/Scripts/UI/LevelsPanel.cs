using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField]
    Button[] _levelsButtons;



    private void Awake()
    {
        foreach (Button levelButton in _levelsButtons)
        {
            levelButton.onClick.AddListener(delegate { LevelButtonClicked(2); });

        }
    }

    /*private void LevelButtonClicked()
    {
        UiManager.Instance.ShowLevelMenu(true);
    }*/

    private void LevelButtonClicked(int level)
    {
        //UiManager.Instance.PlayLevel(true);
    }

    public void ChooseLevel(int levelIndex)
    {
        //_levelText.text = levelIndex.ToString();
    }
}
