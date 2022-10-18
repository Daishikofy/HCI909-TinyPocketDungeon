using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardData", menuName = "GameData/BoardData", order = 2)]
public class BoardData : ScriptableObject
{
    public int width = 3;
    public int height = 10;
    public BoardCell boardCellPrefab;
    public BoardCellData boardCellData;
}
