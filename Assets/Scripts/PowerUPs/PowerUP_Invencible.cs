using UnityEngine;

public class PowerUP_Invencible : PowerUpBase
{
    [Header("Power Up Invencible")]
    public string messagePowerUP = "You have: THE POWER!";
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetInvencible(true);
        PlayerController.Instance.SetPowerUpText(messagePowerUP);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}
