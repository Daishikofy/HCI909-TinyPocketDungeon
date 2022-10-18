using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField]
    private LevelSelectionButton _levelSelectionPrefab;
    [SerializeField]
    private Transform _levelSelectionParents;

    public int spacing;

    private void Start()
    {
        InstanciateMenu();
    }

    private void InstanciateMenu()
    {
        var levels = GlobalGameState.Instance.config.levels;

        for (int i = 0; i < levels.Length; i++)
        {
            var position = new Vector3(i * spacing, 0, 0);
            LevelSelectionButton button = Instantiate(_levelSelectionPrefab, position, Quaternion.identity, _levelSelectionParents);
            button.Setup(levels[i].levelName, levels[i].thumbnail, i, OnLevelSelected);
        }
    }

    private void OnLevelSelected(int id)
    {
        GlobalGameManager.Instance.LoadLevel(GlobalGameState.Instance.config.levels[id]);
    }
}
