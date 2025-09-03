using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    [Header("Level Setup")]
    public Transform container;
    public List<GameObject> levelList;

    [Header("Pieces Setup")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;
    public List<LevelPieceBase> levelPieces;
    public int piecesNumberStart = 1;
    public int piecesNumberEnd = 1;
    public int piecesNumber = 5;
    public float timeToCreatePieces = 0.2f;

    // privates
    [SerializeField] private int _levelIndex;
    private GameObject _currentLevel;
    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();

    private void Awake()
    {
        CreateLevelPieces();
        // SpawnNextLevel();
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

    private void CreateLevelPieces()
    {

        StartCoroutine(CreateLevelPiecesCoroutine());
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

        _spawnedPieces.Add(spawnedPiece);
        // Debug.Log(" -> Chegou aqui. Há " + _spawnedPieces.Count + " peças criadas.");

    }

    private void CleanSpawnedPieces()
    {
        Debug.Log(" -> chegou aqui. Há " + _spawnedPieces.Count + " peças para DESTRUIR.");
        for (int i = _spawnedPieces.Count -1;  i >= 0; i--)
        {
            Debug.Log("Objeto para destruir: " + _spawnedPieces[i].gameObject.tag);
            Destroy(_spawnedPieces[i].gameObject);
            Debug.Log(" -> OK!");
        }       
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        if (_spawnedPieces.Count > 0)
        {
            CleanSpawnedPieces();
        }        

        for (int i = 0; i < piecesNumberStart; i++)
        {
            CreateLevelPiece(levelPiecesStart);
            yield return new WaitForSeconds(timeToCreatePieces);
        }

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
            yield return new WaitForSeconds(timeToCreatePieces);
        }

        for (int i = 0; i < piecesNumberEnd; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
            yield return new WaitForSeconds(timeToCreatePieces);
        }
    }

    private void Update()
    {
        /* to teste some
        if (Input.GetKeyUp(KeyCode.D))
        {
            SpawnNextLevel();
        }
        */
    }


}
