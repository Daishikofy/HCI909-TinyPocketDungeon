using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MovePlayer(Vector2 newPosition)
    {
        //TODO: Lerp between old and new position
        transform.position = newPosition;
    }
}
