using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card[] cards;
    [SerializeField]
    private Transform[] cardsSpawnPoints;

    private int selectedCardId = -1;
    private int nextEmptySlot = 0;
    private bool isEnabled = false;

    public void SetupInitialHand(Card[] cards)
    {
        this.cards = cards;
        int i = 0;
        while (cards[i] != null)
        { 
            Card currentCard = cards[i];

            currentCard.transform.parent = cardsSpawnPoints[i];
            currentCard.transform.localPosition = Vector2.zero;
            currentCard.transform.localRotation = Quaternion.identity;

            currentCard.SetCardId(i);

            currentCard.onSelected.AddListener(OnCardSelected);
            currentCard.onDeselected.AddListener(OnCardDeselected);
            i++;
        }
        nextEmptySlot = i;
    }

    public void AddCard(Card card)
    {
        //TODO: Behaviour when hand is full!
        if (nextEmptySlot >= cardsSpawnPoints.Length)
        {
            Destroy(card.gameObject);
            return;
        }

        card.transform.parent = cardsSpawnPoints[nextEmptySlot];
        card.transform.localPosition = Vector2.zero;
        card.transform.localRotation = Quaternion.identity;

        card.SetCardId(nextEmptySlot);

        card.onSelected.AddListener(OnCardSelected);
        card.onDeselected.AddListener(OnCardDeselected);

        cards[nextEmptySlot] = card;

        nextEmptySlot += 1;
    }

    public void RemoveCard(int id)
    {
        //Debug.Log(" - - START REMOTION - -");
        int emptyIndex = -1;
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null && cards[i].cardId == id)
            {
                emptyIndex = i;
                //Debug.Log("Destroy" + cards[i].cardData.name);
                Destroy(cards[i].gameObject);
                nextEmptySlot -= 1 ;
                //Debug.Log("Next empty slot : " + nextEmptySlot);
                break;
            }
        }

        if (selectedCardId == id)
        {
            selectedCardId = -1;
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
            if (cards[i] == null)
            {
                return;
            }
           
            //Debug.Log("Move " + cards[i].cardData.cardName + " from " + i + " to " + (i - 1));
            cards[(i - 1)] = cards[i];
            cards[i] = null;
            cards[(i - 1)].transform.parent = cardsSpawnPoints[(i - 1)];
            cards[(i - 1)].transform.localPosition = Vector2.zero;
            cards[(i - 1)].transform.localRotation = Quaternion.identity;

            cards[(i - 1)].SetCardId((i - 1));
        }
        //Debug.Log(" - - END REMOTION - -");
    }

    public bool IsEmpty()
    {
        return nextEmptySlot == 0;
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

    public void EnableHand(bool value)
    {
        foreach (var card in cards)
        {
            if(card != null)
                card.Enable(value);
        }

        if (isEnabled == value) return;
        isEnabled = value;
        if (isEnabled)
        {
            gameObject.transform.position += Vector3.up/2.0f;
        }
        else
        {
            gameObject.transform.position += Vector3.down/2.0f;
        }
    }
}
