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

    private void Start()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetupCard(i);
            cards[i].onSelected.AddListener(OnCardSelected);
            cards[i].onDeselected.AddListener(OnCardDeselected);
        }
    }
    public void AddCard()
    {
        //Add card in the first empty slot
    }

    public void RemoveCard(int id)
    {
        //Remove card with corresponding id from cards
        //Rearange cards to the nearest empty location by using the spawn point order
        // ex : Order is 4,2,1,3,5
        // you remove the first card so tou want to bring back the last cards to fill the hole
        // 3rd transform is going to 1, 5th transform is going to 3
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
