using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float powerUpDuration = 3.5f;
    protected override void Collect()
    {
        base.Collect();
        StartPowerUp();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up for " + powerUpDuration + " seconds.");
        Invoke(nameof(EndPowerUp), powerUpDuration);
    }
    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up: NOW!");
        Destroy(base.gameObject);
    }

}