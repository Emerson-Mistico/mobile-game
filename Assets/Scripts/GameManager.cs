using UnityEngine;
using Ebac.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelRestart") == 1)
        {
            PlayerPrefs.SetInt("ActualLevelNumber", 0);
        }

        Debug.Log("Começou o game Level: " + PlayerPrefs.GetInt("ActualLevelNumber") + " Reset: " + PlayerPrefs.GetInt("LevelRestart"));

    }
}
