using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;
    public GameObject objectToMove;

    public float duration = 1f;

    private int _index = 0;

    private void Start()
    {
        objectToMove.transform.position = positions[0].transform.position;
        NextIndex();

        StartCoroutine(StartMoviment());
    }

    private void NextIndex()
    {
        _index++;

        if (_index >= positions.Count)
        {
            _index = 0;
        }
    }

    IEnumerator StartMoviment()
    {
        float time = 0;

        while (true) 
        {
            var currentPosition = objectToMove.transform.position;

            while (time < duration) 
            {
                objectToMove.transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0f;

            yield return null;
        }        
        
    }

}
