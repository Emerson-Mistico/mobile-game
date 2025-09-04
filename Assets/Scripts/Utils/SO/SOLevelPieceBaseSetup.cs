using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class LevelPieceBaseSetup : ScriptableObject
{

    [Header("Pieces Setup")]
    public ArtManager.ArtType artType;

    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;
    public List<LevelPieceBase> levelPieces;
    public int piecesNumberStart = 1;
    public int piecesNumberEnd = 1;
    public int piecesNumber = 5;

}
