using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{

    // publics
    [Header("Player Setup")]
    public float fowardSpeed = 3.5f;

    [Header("Screen")]
    public string messageStartGame = "ARE YOU READY?";
    public GameObject EndGameScreen;
    public GameObject StartGameScreen;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    // privates
    private Vector3 _position;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;

    void Start()
    {
        // _canRun = false;
        _startPosition = transform.position;
        ResetSpeed();
        
    }

    void Update()
    {

        // if (!_canRun) return;
        _position = target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }

    public void ResetSpeed()
    {
        _currentSpeed = fowardSpeed;
    }

}
