using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    public int cellID = -1;
    public bool isEmpty = true;
    public DungeonRoom dungeonRoom;

    private Color color;

    [SerializeField]
    private SpriteRenderer cellRenderer;

    private void Awake()
    {
        color = cellRenderer.color;
    }

    private void OnMouseOver()
    {
        cellRenderer.color = Color.red;
    }

    private void OnMouseExit()
    {
        cellRenderer.color = color;
    }
}
