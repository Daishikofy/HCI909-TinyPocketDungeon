using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardsData", menuName = "WorldData/CardsData", order = 1)]
public class AllCardsData : ScriptableObject
{
    public CardData[] allCardsData;
}
