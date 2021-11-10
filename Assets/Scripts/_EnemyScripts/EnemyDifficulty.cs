using UnityEngine;

public enum DifficultyEnemyType
{
    ordinary, fast, strong, 
    ordinaryTwoLevel, fastTwoLevel, strongTwoLevel, 
    ordinaryThreeLevel, fastThreeLevel, strongThreeLevel, 
    ordinaryFourLevel, fastFourLevel, strongFourLevel,
    ordinaryFiveLevel, fastFiveLevel, strongFiveLevel,
    ordinarySixLevel, fastSixLevel, strongSixLevel,
    ordinarySevenLevel, fastSevenLevel, strongSevenLevel,
    ordinaryEightLevel, fastEightLevel, strongEightLevel,
    ordinaryNineLevel, fastNineLevel, strongNineLevel,
    ordinaryTenLevel, fastTenLevel, strongTenLevel,
    killer,
    boss1, boss2, boss3, boss4, boss5, boss6, boss7, boss8, boss9, boss10
}

public class EnemyDifficulty : MonoBehaviour
{
    public DifficultyEnemyType _difficultyEnemy;

   
}
