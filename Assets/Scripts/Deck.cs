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
        

        for (int i = 0; i < numberOfCards; i++)
        {
            cards[i] = DrawCard();
        }

        return cards;
    }

    public Card DrawCard()
    {
        int cardId = deckData.deckCardsId[Random.Range(0, deckData.deckCardsId.Length)];

        Card card = Instantiate(GameManager.Instance.levelData.cardPrefab);
        card.Setup(GameManager.Instance.levelData.allCardsData.allCardsData[cardId]);

        return card;
    }
}
