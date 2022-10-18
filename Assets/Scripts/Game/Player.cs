using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attackPower = 1;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AddToAttackPower(int powerBoost)
    {
        attackPower += powerBoost;
    }
    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
    public void MovePlayer(Vector2 newPosition)
    {
        newPosition.y -= 0.25f;
        //Start corroutine to lerp between old and new position
        StartCoroutine("MovePlayerCorroutine", newPosition);
    }

    private IEnumerator MovePlayerCorroutine(Vector2 targetPosition)
    {
        Vector3 step = (targetPosition - (Vector2)transform.position) / 50.0f;
        while (Vector2.Distance(transform.position, targetPosition) > step.magnitude)
        {
            transform.position += step;
            yield return null;
        }
        GameManager.Instance.OnPlayerMoved();
    }
}
