using UnityEngine;
using TMPro;
using System.Threading.Tasks;

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
    private async void Select()
    {
        if (isSelected == true) return;

        Vector2 startPosition = controller.transform.position;
        Vector2 targetPosition = new Vector3(startPosition.x, startPosition.y + 1);
        //Vector2 currentPosition = startPosition;
        //disable collider during animation
        Collider2D[] colliders = controller.GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        float velocity = 0.01f;

        //lerp between start and final position
        while (new Vector2(controller.transform.position.x, controller.transform.position.y) != targetPosition)
        {
            controller.transform.position = Vector2.Lerp(controller.transform.position, targetPosition, velocity);
            velocity += 0.0001f;
            await Task.Delay(1);
        }

        //enable collider again
        foreach (Collider2D col in colliders)
        {
            col.enabled = true;
        }

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
