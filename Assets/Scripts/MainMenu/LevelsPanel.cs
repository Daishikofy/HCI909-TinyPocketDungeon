using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField]
    private LevelSelectionButton _levelSelectionPrefab;
    [SerializeField]
    private Transform _levelSelectionParents;

    [SerializeField]
    private float horizontalSpacing = 1.5f;
    [SerializeField]
    private float verticalSpacing = 2.0f;


    private void Start()
    {
        InstanciateMenu();
    }

    private void InstanciateMenu()
    {
        var levels = GlobalGameState.Instance.config.levels;
        float verticalOffset = verticalSpacing;

        for (int i = 0; i < levels.Length; i++)
        {
            if (i % 3 == 0)
            {
                verticalOffset -= verticalSpacing;
            }

            var position = new Vector3((i%3) * horizontalSpacing, verticalOffset, 0.0f) +_levelSelectionParents.position;
            LevelSelectionButton button = Instantiate(_levelSelectionPrefab, position, Quaternion.identity, _levelSelectionParents);
            button.Setup(levels[i].levelName, levels[i].thumbnail, i, OnLevelSelected);
        }
    }

    private void OnLevelSelected(int id)
    {
        GlobalGameManager.Instance.LoadLevel(GlobalGameState.Instance.config.levels[id]);
    }
}
