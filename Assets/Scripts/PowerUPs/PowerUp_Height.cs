using UnityEngine;

public class PowerUp_Height : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2;
    public float animationDurationBegin = 1.5f;
    public float animationDurationEnd = 1.5f;
    public string messagePowerUP = "You have: the HIGH GROUND!";

    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountHeight, powerUpDuration, animationDurationBegin, ease);
        PlayerController.Instance.SetPowerUpText(messagePowerUP);

    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetHeight(animationDurationEnd);
        PlayerController.Instance.SetPowerUpText("");
    }
}
