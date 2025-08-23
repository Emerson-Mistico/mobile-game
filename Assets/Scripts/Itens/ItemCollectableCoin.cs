using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{

    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;
    protected override void OnCollected()
    {

        base.OnCollected();
        ItemManager.Instance.AddItemCoins(itemValue);
        collect = true;

    }
    private void Update()
    {

        if (collect == true)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                Destroy(gameObject);
            }            
        }
    }
}
