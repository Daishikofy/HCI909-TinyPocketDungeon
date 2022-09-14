using System;
using UnityEngine;
using UnityEngine.Events;


public class DragAndDropElement : MonoBehaviour
{
    private bool isSelected = false;
    private Collider2D _collider;

    private UnityEvent onHolding;
    private UnityEvent onReleased;

    private void Awake()
    {
        _collider = gameObject.AddComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (isSelected)
        {
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, 0.1f);
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
        transform.localScale = Vector3.one * 1.2f;
        onHolding.Invoke();
    }

    private void OnMouseUp()
    {
        isSelected = false;
        transform.localScale = Vector3.one;
        onReleased.Invoke();
    }
}

