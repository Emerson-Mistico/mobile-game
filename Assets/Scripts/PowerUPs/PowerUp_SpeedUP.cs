using UnityEngine;

public class PowerUp_SpeedUP: PowerUpBase
{

    [Header("Item Setup Speed")]
    public float amountToSpeed = 7f;
    public string messagePowerUP = "You have: Speed!";

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerUpText(messagePowerUP);

    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }

}
