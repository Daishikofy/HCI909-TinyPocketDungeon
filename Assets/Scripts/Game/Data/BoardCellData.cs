using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardCellData", menuName = "GameData/BoardCellData", order = 3)]
public class BoardCellData : ScriptableObject
{
    [System.Serializable]
    public class CellSprites
    {   
        public Sprite empty;
        public Sprite occupied;
    }

    public CellSprites cellSprites;
}
