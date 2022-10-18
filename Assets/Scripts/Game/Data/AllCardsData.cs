using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CardsData", menuName = "WorldData/CardsData", order = 1)]
public class AllCardsData : ScriptableObject
{
    public CardData[] cards;
    public UnityAction[] cardMagics = { MovePlayer
            , SwordMagic 
            , HourglassMagic
            , PegasusBootsMagic
    };
    public UnityAction[] disableCardMagic =
    {
        MovePlayer
        , RemoveSwordMagic
        , RemoveHourglassMagic
        , RemovePegasusBootsMagic
    };

    private static void MovePlayer()
    {
        Debug.Log("MOVE PLAYER MAGIC");
    }

    private static void SwordMagic()
    {
        GameManager.Instance.player.AddToAttackPower(1);
        GameManager.Instance.gameState.SetMagicTimer((int)ECardMagic.Sword, 3);
    }

    private static void RemoveSwordMagic()
    {
        GameManager.Instance.player.AddToAttackPower(-1);
    }

    private static void PegasusBootsMagic()
    {
        var gameState = GameManager.Instance.gameState;
        gameState.maxActions = 2;
        gameState.SetMagicTimer((int)ECardMagic.PegasusBoots, 3);
    }

    private static void RemovePegasusBootsMagic()
    {
        GameManager.Instance.gameState.maxActions = 1;
    }

    private static void HourglassMagic()
    {
        var gameState = GameManager.Instance.gameState;
        gameState.boardMovingVelocity = 0.5f;
        gameState.SetMagicTimer((int)ECardMagic.Hourglass, 4);
    }

    private static void RemoveHourglassMagic()
    {
        GameManager.Instance.gameState.boardMovingVelocity = 1.0f;
    }
}
