using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public DeckData deckData;

    private void Awake()
    {
        deckData = SaveLoad.LoadDeckData();
        if(deckData == null)
        {
            //Use default deck
            int[] ids = { 0, 0, 0, 1, 1, 2, 2, 3, 3, 4};
            deckData = new DeckData(ids);
        }
    }

    public Card[] DrawCards(int numberOfCards)
    {
        Card[] cards = new Card[numberOfCards];
        Card cardPrefab = GameManager.Instance.levelData.cardPrefab;

        for (int i = 0; i < numberOfCards; i++)
        {
            int cardId = deckData.deckCardsId[Random.Range(0, deckData.deckCardsId.Length)];

            cards[i] = Instantiate(cardPrefab);
            cards[i].Setup(GameManager.Instance.levelData.allCardsData.allCardsData[cardId]);
        }

        return cards;
    }
}
