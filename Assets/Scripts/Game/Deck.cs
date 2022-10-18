using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public DeckData deckData;

    private CardData _currentCardData;

    private void Awake()
    {
        deckData = SaveLoad.LoadDeckData();
        if(deckData == null)
        {
            //Use default deck
            int[] ids = { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3};
            deckData = new DeckData(ids);
        }
    }

    public Card[] DrawCards(int numberOfCards)
    {
        Card[] cards = new Card[5];
        

        for (int i = 0; i < numberOfCards; i++)
        {
            DrawCardLogic();

            Card card = Instantiate(GameManager.Instance.levelData.cardPrefab);
            card.Setup(_currentCardData);
            cards[i] = card;
        }

        return cards;
    }

    public void DrawCard()
    {
        DrawCardLogic();
        UiManager.Instance.DrawCard(_currentCardData, InstanciateCardAndAddToHand);
    }


    private void DrawCardLogic()
    {
        int cardId = deckData.deckCardsId[Random.Range(0, deckData.deckCardsId.Length)];
        _currentCardData = GameManager.Instance.levelData.cardsData.allCardsData[cardId];
    }

    private void InstanciateCardAndAddToHand()
    {
        Card card = Instantiate(GameManager.Instance.levelData.cardPrefab);
        card.Setup(_currentCardData);

        GameManager.Instance.AddCardToHand(card);
    }
}
