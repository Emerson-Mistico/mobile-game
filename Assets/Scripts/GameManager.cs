using UnityEngine;
using Ebac.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Player Item Init Setup")]
    public int initialCoins = 0;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelRestart") == 1)
        {
            PlayerPrefs.SetInt("ActualLevelNumber", 0);
            PlayerPrefs.SetInt("Totalcoins", initialCoins);
        }        
    }
}
