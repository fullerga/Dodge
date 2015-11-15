using System;

public class FasterEnemyPowerUp : PowerUp
{
    public string Tag { get { return "faster"; } }
    public string TextForAnimation { get { return "FASTER ENEMIES"; } }
    public Action StartPowerup { get { return () => PowerUpManager.IsFast = true; } }
}