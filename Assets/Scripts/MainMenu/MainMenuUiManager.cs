using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUiManager : MonoBehaviour
{
    [SerializeField]
    LevelsPanel _levelsPanel;

    // Start is called before the first frame update
    void Awake()
    {
        _levelsPanel.gameObject.SetActive(true);
    }

    public void ShowLevelMenu(bool value)
    {
        _levelsPanel.gameObject.SetActive(true);
    }
}
