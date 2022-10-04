using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attackPower = 1;
    public void MovePlayer(Vector2 newPosition)
    {
        //TODO: Lerp between old and new position
        newPosition.y -= 0.25f;
        transform.position = newPosition;
        GameManager.Instance.OnPlayerMoved();
    }
}
