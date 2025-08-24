using UnityEngine;

public class PowerUp_CollectCois : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 7;
    public string messagePowerUP = "Money, money, money, moooooney!";

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
        PlayerController.Instance.SetPowerUpText(messagePowerUP);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(1);
        PlayerController.Instance.SetPowerUpText("");
    }

}
