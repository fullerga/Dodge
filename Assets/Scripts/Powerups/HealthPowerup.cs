using System;

public class HealthPowerup : PowerUp
{
    public string Tag { get { return "health"; } }
    public string TextForAnimation { get { return "RESTORE HEALTH"; } }
    public Action StartPowerup
    {
        get
        {
            return () =>
            {
                PowerUpManager.HealthBar.IncHealth();
                PowerUpManager.Reset();
            };
        }
    }
}
