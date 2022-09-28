using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card[] cards;
    [SerializeField]
    private Transform[] cardsSpawnPoints;
    [SerializeField]
    private int[] spawnPointsOrder;

    private int selectedCardId = -1;

    public void SetupInitialHand(Card[] cards)
    {
        this.cards = cards;
        for (int i = 0; i < cards.Length; i++)
        {
            Card currentCard = cards[i];

            currentCard.transform.parent = cardsSpawnPoints[i];
            currentCard.transform.localPosition = Vector2.zero;
            currentCard.transform.localRotation = Quaternion.identity;

            currentCard.SetCardId(i);

            currentCard.onSelected.AddListener(OnCardSelected);
            currentCard.onDeselected.AddListener(OnCardDeselected);
        }
    }

    public void DrawCards(int numberOfCards)
    {
        
    }

    public void AddCard()
    {
        //Add card in the first empty slot
    }

    public void RemoveCard(int id)
    {
        int emptyIndex = -1;
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null && cards[i].cardId == id)
            {
                emptyIndex = i;
                cards[i].gameObject.SetActive(false);
            }
        }

        //Remove card with corresponding id from cards
        //Rearange cards to the nearest empty location by using the spawn point order
        // ex : Order is 3,2,4,1,5
        // you remove the first card so tou want to bring back the last cards to fill the hole
        // 3rd transform is going to 1, 5th transform is going to 3
        if (emptyIndex == -1)
        {
            Debug.Log("No card was removed");
            return;
        }
        for (int i = emptyIndex + 1; i < cards.Length; i++)
        {
            int previousIndex = spawnPointsOrder[i - 1];
            int currentIndex = spawnPointsOrder[i];
            Debug.Log("Move " + cards[currentIndex].cardData.cardName + " from " + currentIndex + " to " + previousIndex);
            cards[previousIndex] = cards[currentIndex];

            Debug.Log( cards[currentIndex].cardData.cardName + " is now in " + cardsSpawnPoints[previousIndex].name);
            cards[previousIndex].transform.parent = cardsSpawnPoints[previousIndex];
            cards[previousIndex].transform.localPosition = Vector2.zero;
            cards[previousIndex].transform.localRotation = Quaternion.identity;

            cards[previousIndex].SetCardId(previousIndex);
        }
    }

    public void OnCardSelected(int cardId)
    {
        if (selectedCardId == cardId) return;

        if(selectedCardId != -1)
        {
            cards[selectedCardId].Deselect();
        }
        selectedCardId = cardId;
        GameManager.Instance.OnCardSelected(cards[cardId]);
    }
    public void OnCardDeselected(int cardId)
    {
        selectedCardId = -1;
        GameManager.Instance.OnCardDeselected();
    }
}
