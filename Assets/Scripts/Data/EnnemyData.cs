using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyData", menuName = "GameData/EnnemyData")]
public class EnnemyData : ScriptableObject
{
    public int[] loot;
    public int maxLifePoints = 1;
    public Sprite sprite;
}
