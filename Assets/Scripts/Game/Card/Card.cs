
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Card : DragAndDropElement
{
    public CardData cardData;
    public UnityEvent<int> onSelected, onDeselected;
    public int cardId { get; private set; } = -1;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    TextMeshPro textMesh;

    private CardView _view;

    public void Setup(CardData cardData)
    {
        this.cardData = cardData;

        _view = new CardView(this, spriteRenderer, textMesh);
        onSelected = new UnityEvent<int>();
    }

    public void SetCardId(int id)
    {
        cardId = id;
    }
       
    public void OnSelected(bool value)
    {
        if (value)
            onSelected.Invoke(cardId);
        else
            onDeselected.Invoke(cardId);
    }

    public void Deselect()
    {
        _view.Deselect();
    }

    private void OnMouseEnter()
    {
        _view.OnMouseEnter();
    }

    private void OnMouseDown()
    {
        _view.OnMouseDown();
    }

    private void OnMouseExit()
    {
        _view.OnMouseExit();
    }

    public void Enable(bool value)
    {
        _view.EnableColliders(value);
    }
}
