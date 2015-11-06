using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static bool IsInvincible;
    public static bool IsSlow;
    public static bool IsFast;
    public static bool IsReverse;

    static float powerUpStartTime;
    const int PowerUpTime = 10;
    static HealthBar healthBar;

    void Start()
    {
        Reset();
        healthBar = GameObject.Find("health").GetComponent<HealthBar>();
    }

    void Update()
    {
        if (PowerUpOver())
            Reset();
    }

    public static void SetPowerUp(string tag)
    {
        Reset();
        switch (tag)
        {
            case "invincible":
                IsInvincible = true;
                break;
            case "slower":
                IsSlow = true;
                break;
            case "faster":
                IsFast = true;
                break;
            case "reverse":
                IsReverse = true;
                break;
            case "health":
                healthBar.IncHealth();
                break;
            default:
                throw new UnityException("Could not find powerup for " + tag);
        };
    }

    static void Reset()
    {
        powerUpStartTime = Time.time;
        IsInvincible = false;
        IsSlow = false;
        IsFast = false;
        IsReverse = false;
    }

    static bool PowerUpOver()
    {
        var diff = Time.time - powerUpStartTime;
        var seconds = (int)diff % 60;
        return seconds >= PowerUpTime;
    }
}
