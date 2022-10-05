using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    static private UiManager _instance;

    [SerializeField]
    TextMeshProUGUI GameText;
    [SerializeField]
    
    public static UiManager Instance { get => _instance; private set => _instance = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this);

        _instance = this;
    }
}
