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

    public ParticleSystem particle;

    [Header("Sounds")]
    public AudioSource soundToUse;

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
            Destroy(gameObject);
        }            
        
        OnCollected();
    }
    
    protected virtual void OnCollected()
    {
        
        if (particle != null)
        {
            particle.Play();
            StartCoroutine(WaitAndDeactivate(particle.main.duration));
        }
        else
        {
            gameObject.SetActive(false);
        }

        if (soundToUse != null) { 
            soundToUse.Play(); 
        }        

    }
        
    private IEnumerator WaitAndDeactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    
}
