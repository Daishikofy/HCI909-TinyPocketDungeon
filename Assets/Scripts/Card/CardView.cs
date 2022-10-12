using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Collections;
using System;

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

        //disable colliders during animation
        Collider2D[] colliders = controller.GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        controller.StartCoroutine(SelectCoroutine());

        //enable colliders again
        foreach (Collider2D col in colliders)
        {
            col.enabled = true;
        }

        isSelected = true;
        controller.OnSelected(true);
    }
    public async void Deselect()
    {
        if (isSelected == false) return;

        //disable colliders during animation
        Collider2D[] colliders = controller.GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        controller.StartCoroutine(DeselectCoroutine());

        //enable colliders again
        foreach (Collider2D col in colliders)
        {
            col.enabled = true;
        }

        isSelected = false;
        controller.OnSelected(false);
    }

    IEnumerator SelectCoroutine()
    {
        Vector2 startPosition = controller.transform.position;
        Vector2 targetPosition = new Vector2(startPosition.x, startPosition.y + 1); //up one

        float velocity = 0.01f;
        float maxVelocity = 0.4f;

        //lerp between start and final position
        while (Mathf.Abs(targetPosition.y - controller.transform.position.y) > 0.1f)
        {
            controller.transform.position = Vector2.Lerp(controller.transform.position, targetPosition, velocity);
            if (velocity < maxVelocity)
                velocity += 0.001f; //smooth anim

            yield return null; //keep going until while loop is finished
        }
        yield return new WaitForSeconds(1);
    }

    private IEnumerator DeselectCoroutine()
    {
        Vector2 startPosition = controller.transform.position;
        Vector2 targetPosition = new Vector2(startPosition.x, startPosition.y - 1); //down one

        float velocity = 0.01f;
        float maxVelocity = 0.4f;

        //lerp between start and final position
        while (Mathf.Abs(targetPosition.y - controller.transform.position.y) > 0.1f)
        {
            controller.transform.position = Vector2.Lerp(controller.transform.position, targetPosition, velocity);
            if (velocity < maxVelocity)
                velocity += 0.001f; //smooth anim

            yield return null; //keep going until while loop is finished
        }
        yield return new WaitForSeconds(1);
    }
}
