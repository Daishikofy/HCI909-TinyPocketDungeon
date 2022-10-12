using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{
    [SerializeField]
    Animation rollDiceAnimation;

    private UnityAction _onDiceRolled;

    public void SetupDice(UnityAction onDiceRolled)
    {
        _onDiceRolled = onDiceRolled;
    }
    public void ShowDice()
    {
        gameObject.SetActive(true);
    }

    private void RollDice()
    {
        rollDiceAnimation.Play();
    }

    private void OnMouseDown()
    {
        Debug.Log("CLICK");
        RollDice();
    }

    public void OnDiceRolled()
    {
        gameObject.SetActive(false);
        _onDiceRolled();
    }


}
