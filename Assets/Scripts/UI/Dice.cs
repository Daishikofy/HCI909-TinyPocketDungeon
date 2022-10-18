using UnityEngine;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{
    [SerializeField]
    Animation _diceAnimation;

    [SerializeField]
    Animation showDice;

    private UnityAction _onDiceRolled;

    public void SetupDice(UnityAction onDiceRolled)
    {
        _onDiceRolled = onDiceRolled;
    }
    public void ShowDice()
    {
        gameObject.SetActive(true);
        
    }

    private void OnEnable()
    {
        _diceAnimation.Play("Dice_Show");
    }

    private void RollDice()
    {
        _diceAnimation.Play("Dice_Roll");
    }

    private void OnMouseDown()
    {
        RollDice();
    }

    public void OnDiceRolled()
    {
        gameObject.SetActive(false);
        _onDiceRolled();
    }


}
