using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "GameData/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public BoardData boardData;

    public Ennemy ennemyPrefab;
    public EnnemyData[] ennemies;

    public Card cardPrefab;
    public AllCardsData cardsData;
}
