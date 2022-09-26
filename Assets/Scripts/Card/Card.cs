using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : DragAndDropElement
{
    public CardData cardData;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    TextMeshPro textMesh;

    CardView view;

    private void Awake()
    {
        view = new CardView(this, spriteRenderer, textMesh);
    }

    public void SelectCard()
    {
        if (GameManager.Instance == null)
            Debug.Log("Fuck");
        GameManager.Instance.OnCardSelected(this);
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
