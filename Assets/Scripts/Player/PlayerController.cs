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

    [Header("Animation Manager")]
    public AnimatorManager animatorManager;

    public bool invencible = false;

    [Header("Screen")]
    public string messageStartGame = "Are You Ready?";
    public string messageNextLevel = "Congratulations!";
    public string messageTryAgain = "Oh No! Try again?";
    public string messageEndGame = "END GAME. YOU WIN!";
    public GameObject startGameScreen;
    public GameObject endGameScreen;
    public GameObject hudShowCoins;

    public TextMeshPro uiTextPowerUp;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1.0f;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Menu Setup")]
    public GameObject buttonReset;
    public GameObject buttonNextLevel;

    // privates
    private Vector3 _position;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedAnimation = 7;

    private int _currentLevelNumber;

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
        _currentLevelNumber = PlayerPrefs.GetInt("ActualLevelNumber");

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

    private void OnCollisionEnter(Collision collision)
    {
        if (!invencible && collision.gameObject.tag == tagToCheckBarrier) 
        {
            SetPowerUpText(messageTryAgain);
            _currentLevelNumber = 0;

            buttonReset.SetActive(true);

            MoveBack();
            EndGame(_currentLevelNumber, 1, AnimatorManager.AnimationType.DEAD);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagTocheckEndLine)
        {
            SetPowerUpText(messageNextLevel);

            _currentLevelNumber++;

            if (_currentLevelNumber >= PlayerPrefs.GetInt("LevelMax"))
            {
                _currentLevelNumber = 0;
                SetPowerUpText(messageEndGame);
                buttonReset.SetActive(true);
            } else
            {
                buttonNextLevel.SetActive(true);
            }                

            EndGame(_currentLevelNumber, 0);
        }      
    }
    #region UTILS
    private void MoveBack() {
        transform.DOMoveZ(-2f, 0.3f).SetRelative();
    }

    public void StartToRun()
    {
        _canRun = true;
        SetPowerUpText("");
        startGameScreen.SetActive(false);
        hudShowCoins.SetActive(true);
        animatorManager.PlayAnimation(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedAnimation);
    }
    private void EndGame(int levelToUpdate, int levelRestart, AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {        
        _canRun = false;
        endGameScreen.SetActive(true);
        animatorManager.PlayAnimation(animationType);
        PlayerPrefs.SetInt("ActualLevelNumber", levelToUpdate);
        PlayerPrefs.SetInt("LevelRestart", levelRestart);
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

    #region POWER UPS 
        
    public void PowerUpSpeedUp(float amountSpeed)
    {
        _currentSpeed = amountSpeed;
    }
    public void SetInvencible(bool canDie)
    {
        invencible = canDie;
    }
    public void ChangeHeight(float amountToHigh, float timePowerUp, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amountToHigh, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), timePowerUp);
    }
    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }
    public void ChangeCoinCollectorSize(float distanceSize)
    {
        coinCollector.transform.localScale = Vector3.one * distanceSize;
    }
    #endregion

}
