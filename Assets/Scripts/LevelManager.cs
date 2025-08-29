using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public Transform container;

    public List<GameObject> levelList;

    [SerializeField] private int _levelIndex;

    private void Awake()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        var currentLevel = Instantiate(levelList[_levelIndex], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }



}
