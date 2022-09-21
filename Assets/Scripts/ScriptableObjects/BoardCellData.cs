using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardCellData", menuName = "GameData/BoardCellData", order = 3)]
public class BoardCellData : ScriptableObject
{
    [System.Serializable]
    public class CellSprites
    {   
        public Sprite center;
        public Sprite left;
        public Sprite right;


        public Sprite top;
        public Sprite topLeft;
        public Sprite topRight;


        public Sprite bottom;
        public Sprite bottomLeft;
        public Sprite bottomRight;
    }

    public CellSprites cellSprites;
}
