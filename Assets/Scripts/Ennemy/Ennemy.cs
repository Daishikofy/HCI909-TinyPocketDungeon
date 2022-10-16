using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ennemy : MonoBehaviour
{
    private EnnemyModel _model;
    public EnnemyView _view;

    [SerializeField]
    private SpriteRenderer _pawnThumbnail;
    public void SetupEnnemy(EnnemyData data, UnityAction onDefeatedCallback)
    {
        _model = new EnnemyModel(data);
        _model.onDefeated.AddListener(onDefeatedCallback);
        _model.onDefeated.AddListener(_view.OnDefeated);
        _view = new EnnemyView(this, _model, _pawnThumbnail);
    }

    private void OnDefeated()
    {
        _view.OnDefeated();
    }
    private void GetLoot()
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
    }

    public void OnAttacked(int damages)
    {
        _view.OnAttacked();
        _model.currentLifePoints -= damages;
    }
}
