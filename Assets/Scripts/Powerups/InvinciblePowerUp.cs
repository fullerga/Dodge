using System;

public class InvinciblePowerUp : PowerUp
{
    public string Tag { get { return "invincible"; } }
    public string TextForAnimation { get { return "INVINCIBLE"; } }
    public Action StartPowerup { get { return () => PowerUpManager.IsInvincible = true; } }
}