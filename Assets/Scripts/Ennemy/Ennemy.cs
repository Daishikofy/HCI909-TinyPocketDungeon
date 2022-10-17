using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ennemy : MonoBehaviour
{
    public EnnemyModel _model;
    private EnnemyView _view;

    [SerializeField]
    private SpriteRenderer _pawnThumbnail;

    [SerializeField]
    private SpriteRenderer[] _lifePoints;

    private UnityAction _onDefeatedCallback;
    public void SetupEnnemy(EnnemyData data, UnityAction onDefeatedCallback)
    {
        _model = new EnnemyModel(data);
        _onDefeatedCallback = onDefeatedCallback;
        _model.onDefeated.AddListener(OnDefeated);
        _view = new EnnemyView(this, _model, _pawnThumbnail, _lifePoints);
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
        UiManager.Instance.LootEarned(money, _onDefeatedCallback);
    }

    public void OnAttacked(int damages)
    {
        _view.OnAttacked();
        _model.currentLifePoints -= damages;
    }
}
