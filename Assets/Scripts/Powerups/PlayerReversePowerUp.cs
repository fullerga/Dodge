using System;

public class PlayerReversePowerUp : PowerUp
{
    public string Tag { get { return "reverse"; } }
    public string TextForAnimation { get { return "REVERSE"; } }
    public Action StartPowerup { get { return () => PowerUpManager.IsReverse = true; } }
}