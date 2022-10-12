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
        Debug.Log("SWORD MAGIC");
    }

    private static void PegasusBootsMagic()
    {
        Debug.Log("BOOTS MAGIC");
    }

    private static void HourglassMagic()
    {
        Debug.Log("HOURGLASS MAGIC");
    }
}
