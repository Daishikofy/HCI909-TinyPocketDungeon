using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField]
    Button[] _levelsButtons;



    private void Awake()
    {

        for (int i = 0; i < _levelsButtons.Length; i++)
        {
            int x = i;
            _levelsButtons[i].onClick.AddListener(delegate { LevelButtonClicked(x); });
        }
    }

    /*private void LevelButtonClicked()
    {
        UiManager.Instance.ShowLevelMenu(true);
    }*/

    private void LevelButtonClicked(int level)
    {
        //UiManager.Instance.PlayLevel(true);
        Debug.Log(level);
    }

    public void ChooseLevel(int levelIndex)
    {
        //_levelText.text = levelIndex.ToString();
    }
}
