using System;

public class SlowerEnemyPowerUp : PowerUp
{
    public string Tag { get { return "slower"; } }
    public string TextForAnimation { get { return "SLOWER ENEMIES"; } }
    public Action StartPowerup { get { return () => PowerUpManager.IsSlow = true; } }
}