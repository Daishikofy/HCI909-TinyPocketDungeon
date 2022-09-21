using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "GameData/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public BoardData boardData;
}
