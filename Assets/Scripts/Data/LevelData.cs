using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "GameData/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public BoardData boardData;

    public float gameOverHeight = -3.44f;

    public Ennemy ennemyPrefab;
    public EnnemyData[] ennemies;

    public Card cardPrefab;
    public AllCardsData cardsData;
}
