using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float powerUpDuration = 3.5f;
    public Material powerUpMaterial;

    protected override void Collect()
    {
        base.Collect();
        StartPowerUp();
    }
    protected virtual void StartPowerUp()
    {
        PlayerController.Instance.ChangeParticlesColor(powerUpMaterial.color);
        PlayerController.Instance.playerParticles.SetActive(true);
        Invoke(nameof(EndPowerUp), powerUpDuration);
    }
    protected virtual void EndPowerUp()
    {
        PlayerController.Instance.playerParticles.SetActive(false);
        Destroy(base.gameObject);        
    }

}