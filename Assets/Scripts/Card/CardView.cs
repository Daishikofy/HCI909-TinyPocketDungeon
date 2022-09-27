using UnityEngine;
using TMPro;

public class CardView
{
    private Card controller;

    private SpriteRenderer cardRenderer;
    private TextMeshPro cardText;

    private Color defaultColor;
    private Color highlightColor = Color.red;

    private bool isSelected = false;
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
        if (!isSelected)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }
    private void Select()
    {
        if (isSelected == true) return;

        Vector2 newPosition = controller.transform.position;
        newPosition.y += 1;
        controller.transform.position = newPosition;
        isSelected = true;

        controller.OnSelected(true);
    }
    public void Deselect()
    {
        if (isSelected == false) return;

        Vector2 newPosition = controller.transform.position;
        newPosition.y -= 1;
        controller.transform.position = newPosition;
        isSelected = false;

        controller.OnSelected(false);
    }
}
