using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckData
{
    public int[] deckCardsId;
    public DeckData(int[] deckCardsId)
    {
        this.deckCardsId = deckCardsId;
    }
}
