using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("Collect Setup")]
    public string tagToCompare = "Player";
    public string tagCoins = "Coin";
    public int itemValue = 1;
       
    public GameObject graphicItem;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {     

        if(!transform.CompareTag(tagCoins))
        {
            gameObject.SetActive(false);
            // Debug.Log("Object! BUMM!");
        } else
        {
            OnCollected();
        } 

    }
    
    protected virtual void OnCollected()
    {
        // Debug.Log("Entrou no -> OnCollected");        
    }
    
}
