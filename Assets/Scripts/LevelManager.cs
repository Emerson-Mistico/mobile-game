using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    [Header("Level Setup")]
    public Transform container;
    public List<GameObject> levelList;

    // privates
    [SerializeField] private int _levelIndex;
    private GameObject _currentLevel;

    private void Awake()
    {
        SpawnNextLevel();
    }

    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _levelIndex++;
        }

        if (_levelIndex >= levelList.Count)
        {
            ResetLevelIndex();
        }

        _currentLevel = Instantiate(levelList[_levelIndex], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _levelIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            SpawnNextLevel();
        }
    }


}
