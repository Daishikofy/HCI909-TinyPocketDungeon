using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    static GlobalGameManager _instance;
    public static GlobalGameManager Instance { get => _instance; }

    [Header("Scenes names")]
    [SerializeField]
    private string mainMenuSceneName;
    [SerializeField]
    private string gameSceneName;

    [HideInInspector]//Unity property to hide a public field in the inspector, does not impact any system's logic
    public LevelData currentLevel;

    private void Awake()
    {
        if (_instance != null)
            Destroy(this);
        else
            _instance = this;

        //Tells Unity to keep this object alive even when changing scene.
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }

    public void LoadLevel(LevelData level)
    {
        currentLevel = level;
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }
}
