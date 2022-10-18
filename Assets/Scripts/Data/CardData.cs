using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "GameData/CardData", order = 4)]
public class CardData : ScriptableObject
{
    public string cardName = "Default Name";
    public ECardMagic cardMagic = ECardMagic.PlayerMovement;
    public Sprite cardVisual;
    public AudioClip selectSound;
    public AudioClip deselectSound;

}
