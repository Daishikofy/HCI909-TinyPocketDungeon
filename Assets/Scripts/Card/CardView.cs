using UnityEngine;
using TMPro;

public class CardView
{
    Card controller;

    SpriteRenderer cardRenderer;
    TextMeshPro cardText;

    Color defaultColor;
    Color highlightColor = Color.red;

    public CardView(Card controller, SpriteRenderer spriteRenderer, TextMeshPro textMesh)
    {
        this.controller = controller;

        cardRenderer = spriteRenderer;
        cardText = textMesh;

        cardRenderer.sprite = controller.cardData.cardVisual;
        defaultColor = cardRenderer.color;

        cardText.text = controller.cardData.cardName;
    }

    public void OnMouseEnter()
    {
        cardRenderer.color = highlightColor;
    }

    public void OnMouseExit()
    {
        cardRenderer.color = defaultColor;
    }

    public void OnMouseDown()
    {
        Vector2 newPosition = controller.transform.position;
        newPosition.y += 1;
        controller.transform.position = newPosition;
        controller.SelectCard();
    }
}
