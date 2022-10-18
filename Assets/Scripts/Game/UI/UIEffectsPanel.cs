using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIEffectsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinEffectContainer;
    [SerializeField]
    private TextMeshProUGUI _coinText;
    [SerializeField]
    private Animation _lootAnimation;


    private UnityAction _lootAnimationCallback;

    private void Awake()
    {
        _coinEffectContainer.SetActive(false);
    }
    public void OnLootEarned(int coins, UnityAction callback)
    {
        _lootAnimationCallback = callback;
        _coinEffectContainer.SetActive(true);
        _coinText.text = "+" + coins.ToString();
        _lootAnimation.Play();
    }

    public void OnLootAnimationEnded()
    {
        _coinEffectContainer.SetActive(false);
        _lootAnimationCallback();
    }

}
