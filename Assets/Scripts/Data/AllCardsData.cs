using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CardsData", menuName = "WorldData/CardsData", order = 1)]
public class AllCardsData : ScriptableObject
{
    public CardData[] allCardsData;
    public UnityAction[] cardMagics = { MovePlayer
            , SwordMagic 
            , HourglassMagic
            , PegasusBootsMagic
    };

    private static void MovePlayer()
    {
        Debug.Log("MOVE PLAYER MAGIC");
    }

    private static void SwordMagic()
    {
        GameManager.Instance.gameState.SetPlayerPower(1, 3);
    }

    private static void PegasusBootsMagic()
    {
        GameManager.Instance.gameState.SetMaxActions(2, 3);
    }

    private static void HourglassMagic()
    {
        GameManager.Instance.gameState.SetBoardVelocity(0.5f, 4);
    }
}
