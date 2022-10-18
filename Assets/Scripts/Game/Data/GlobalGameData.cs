using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldData/Configuration", fileName = "Configuration.asset")]
public class GlobalGameData : ScriptableObject
{
    public LevelData[] levels;
    public CardData[] cards;
}
