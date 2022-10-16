using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ennemy : MonoBehaviour
{
    private EnnemyModel _model;
    public EnnemyView _view;

    [SerializeField]
    private SpriteRenderer _pawnThumbnail;

    private UnityAction onDefeatedCallback;
    public void SetupEnnemy(EnnemyData data, UnityAction onDefeatedCallback)
    {
        _model = new EnnemyModel(data);
        this.onDefeatedCallback = onDefeatedCallback;
        _model.onDefeated.AddListener(OnDefeated);
        _view = new EnnemyView(this, _model, _pawnThumbnail);
    }

    private void OnDefeated()
    {
        _view.OnDefeated();
    }
    public void GetLoot()
    {
        List<Card> cards = new List<Card>();
        int money = 0;

        foreach(var loot in _model.data.loot)
        {
            //Negative loot correspond to money while positive loot correspond to card index
            if (loot > 0)
            {
                Card card = Instantiate(GameManager.Instance.levelData.cardPrefab);
                card.Setup(GameManager.Instance.levelData.cardsData.allCardsData[loot]);
                cards.Add(card);
            }
            else
            {
                money += (loot * -1);
            }
        }
            GameManager.Instance.GetLoot(cards, money);
        UiManager.Instance.LootEarned(money, onDefeatedCallback);
    }

    public void OnAttacked(int damages)
    {
        _view.OnAttacked();
        _model.currentLifePoints -= damages;
    }
}
