using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    [Header("Bounce Setup")]
    public GameObject objectToBounce;
    public string tagToCheckPlayer = "Player";
    public float timeToBounce = .3f;
    public float normalSize = 2.32f;
    public Ease ease;
 
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagToCheckPlayer)
        {
            Debug.Log("Opa! Player bateu aqui");
            objectToBounce.transform.DOScale(normalSize * 1.2f, timeToBounce * 0.7f).SetEase(ease).SetLoops(2, LoopType.Yoyo);
        }
    }

}
