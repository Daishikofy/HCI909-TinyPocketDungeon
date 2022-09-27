
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

    private CardView view;

    private void Awake()
    {
        view = new CardView(this, spriteRenderer, textMesh);
        onSelected = new UnityEvent<int>();
    }

    public void SetupCard(int id)
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
        view.Deselect();
    }



    private void OnMouseEnter()
    {
        view.OnMouseEnter();
    }

    private void OnMouseDown()
    {
        view.OnMouseDown();
    }

    private void OnMouseExit()
    {
        view.OnMouseExit();
    }
}
