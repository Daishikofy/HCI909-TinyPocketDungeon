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
    private Color highlightColor = new Color(0.5f, 0.5f, 0.5f);

    private AudioSource audioSource;
    private Collider2D[] colliders;

    private bool isSelected = false;
    public CardView(Card controller, SpriteRenderer spriteRenderer, TextMeshPro textMesh)
    {
        this.controller = controller;

        cardRenderer = spriteRenderer;
        cardText = textMesh;

        cardRenderer.sprite = controller.cardData.cardVisual;
        defaultColor = cardRenderer.color;

        audioSource = controller.GetComponent<AudioSource>();
        colliders = controller.GetComponents<Collider2D>();

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

        //disable colliders during animation
        EnableColliders(false);

        //animate card movement up
        controller.StartCoroutine(SelectCoroutine());
    }
    public void Deselect()
    {
        if (isSelected == false) return;

        //disable colliders during animation
        EnableColliders(false);

        //animate card movement down
        controller.StartCoroutine(DeselectCoroutine());
    }

    IEnumerator SelectCoroutine()
    {
        Vector2 startPosition = controller.transform.position;
        Vector2 targetPosition = new Vector2(startPosition.x, startPosition.y + 1); //up one

        float velocity = 0.01f;
        float maxVelocity = 0.4f;

        //play select card sound
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(controller.cardData.selectSound, 0.7F);

        Vector3 step = (targetPosition - (Vector2)controller.transform.position) / 50.0f;
        //lerp between start and final position
        while (Vector2.Distance(controller.transform.position, targetPosition) > step.magnitude)
        {
            controller.transform.position += step;
            yield return null; //keep going until while loop is finished
        }

        //enable colliders again
        EnableColliders(true);

        //set card as selected
        isSelected = true;
        controller.OnSelected(true);
    }

    private IEnumerator DeselectCoroutine()
    {
        Vector2 startPosition = controller.transform.position;
        Vector2 targetPosition = new Vector2(startPosition.x, startPosition.y - 1); //down one

        float velocity = 0.01f;
        float maxVelocity = 0.4f;

        //play deselect card sound
        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(controller.cardData.deselectSound, 0.7F);

        Vector3 step = (targetPosition - (Vector2)controller.transform.position) / 50.0f;
        //lerp between start and final position
        while (Vector2.Distance(controller.transform.position, targetPosition) > step.magnitude)
        {
            controller.transform.position += step;
            yield return null; //keep going until while loop is finished
        }

        //enable colliders again
        EnableColliders(true);

        //set card as deselected
        isSelected = false;
        controller.OnSelected(false);
    }

    public void EnableColliders(bool value)
    {
        foreach (Collider2D col in colliders)
        {
            col.enabled = value;
        }
    }
}
