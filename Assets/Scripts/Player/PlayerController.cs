using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{

    // publics
    [Header("Player Setup")]
    public float fowardSpeed = 3.5f;
    public string tagToCheckBarrier = "Barrier";
    public string tagTocheckEndLine = "EndLine";
    public bool invencible = false;

    [Header("Screen")]
    public string messageStartGame = "Are You Ready?"; // Money, money, money, mooooney!
    public GameObject startGameScreen;
    public GameObject endGameScreen;
    public GameObject hudShowCoins;

    public TextMeshPro uiTextPowerUp;

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
        _canRun = false;
        _startPosition = transform.position;
        startGameScreen.SetActive(true);
        SetPowerUpText(messageStartGame);
        ResetSpeed();        
    }

    void Update()
    {

        if (!_canRun)
        {
            return;
        }

        _position = target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagTocheckEndLine)
        {
            Debug.Log("Endline Check");
            EndGame();
        }
    }

    #region UTILS
    public void StartToRun()
    {
        _canRun = true;
        SetPowerUpText("");
        startGameScreen.SetActive(false);
        hudShowCoins.SetActive(true);
    }
    private void EndGame()
    {
        _canRun = false;
        endGameScreen.SetActive(true);
    }
    public void QuitGameNow()
    {
        Debug.Log("Game is over. Thank You.");
    }

    public void ResetSpeed()
    {
        _currentSpeed = fowardSpeed;
    }
    public void SetPowerUpText(string textToShow)
    {
        uiTextPowerUp.text = textToShow;
    }
    #endregion

}
