using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _titleText;
    [SerializeField]
    private SpriteRenderer _thumbnailRenderer;

    
    private UnityEvent<int> _onClick;

    private int _id;

    private void Awake()
    {
        _onClick = new UnityEvent<int>();
    }

    public void Setup(string title, Sprite thumbnail, int id, UnityAction<int> callBack)
    {
        _titleText.text = title;
        _thumbnailRenderer.sprite = thumbnail;
        _id = id;

        _onClick.AddListener(callBack);
    }

    private void OnMouseDown()
    {
        _onClick.Invoke(_id);
    }
}