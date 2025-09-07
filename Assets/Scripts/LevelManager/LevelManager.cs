using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Ebac.Core.Singleton;

public class LevelManager : Singleton<LevelManager>
{

    [Header("Level Setup")]
    public Transform container;
    public List<GameObject> levelList;

    public List<LevelPieceBaseSetup> levelPieceBaseSetups;

    public float timeToCreatePieces = 0.2f;

    [Header("Level HUD")]
    public SOInt actualLevelToShow;

    // privates
    [SerializeField] private int _levelIndex;
    //private GameObject _currentLevel;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currSetup;

    private void Awake()
    {
        PlayerPrefs.SetInt("LevelMax", levelPieceBaseSetups.Count);
        _levelIndex = PlayerPrefs.GetInt("ActualLevelNumber");        
        //Debug.Log("Awake -> Level Index = " + _levelIndex);
    }

    private void Start()
    {
        CreateLevelPieces(_levelIndex);
        // SpawnNextLevel();
    }

    /*private void SpawnNextLevel()
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
    */

    private void ResetLevelIndex()
    {
        _levelIndex = 0;
        PlayerPrefs.SetInt("ActualLevelNumber", _levelIndex);
    }

    private void CreateLevelPieces(int indexLevelToCreate)
    {       
        CleanSpawnedPieces();        
        /*
        if (_currentLevel != null)
        {           
            if (_levelIndex >= levelPieceBaseSetups.Count) {
                ResetLevelIndex();
            } 
        }*/

        // _levelIndex = PlayerPrefs.GetInt("ActualLevel");

        Debug.Log("Nível atual: " + indexLevelToCreate + " e Prefs: " + PlayerPrefs.GetInt("ActualLevelNumber"));

        _currSetup = levelPieceBaseSetups[indexLevelToCreate];

        for (int i = 0; i < _currSetup.piecesNumberStart; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }

        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }

        for (int i = 0; i < _currSetup.piecesNumberEnd; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);            
        }

        ColorManager.Instance.ChangeColorBytype(_currSetup.artType);

    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePieace(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPieces()
    {
        // Debug.Log(" -> chegou aqui. Há " + _spawnedPieces.Count + " peças para DESTRUIR.");
        for (int i = _spawnedPieces.Count -1;  i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    } 

    private void Update()
    {
        _levelIndex = PlayerPrefs.GetInt("ActualLevelNumber");

        if (Input.GetKeyUp(KeyCode.D))
        {
            _levelIndex++;
            PlayerPrefs.SetInt("ActualLevelNumber", _levelIndex);

            if (_levelIndex >= levelPieceBaseSetups.Count)
            {
                ResetLevelIndex();
            }

            CreateLevelPieces(_levelIndex);
        }

        _levelIndex = PlayerPrefs.GetInt("ActualLevelNumber");

        actualLevelToShow.value = _levelIndex;

    }

}
