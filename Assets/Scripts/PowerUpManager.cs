using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public static bool IsInvincible;
    public static bool IsSlow;
    public static bool IsFast;
    public static bool IsReverse;
    public static HealthBar HealthBar;

    static float PowerUpStartTime;
    const int PowerUpTime = 10;
    static Animation Animation;
    static Text AnimationText;
    static PowerUp[] Powerups;

    void Start()
    {
        Reset();
        HealthBar = GameObject.Find("health").GetComponent<HealthBar>();
        Animation = GameObject.Find("PowerupText").GetComponent<Animation>();
        AnimationText = GameObject.Find("PowerupText").GetComponent<Text>();
        var powerupTypes = AllPowerUps().Where(IsPowerUp);
        Powerups = powerupTypes.Select(type => (PowerUp)type.GetConstructor(Type.EmptyTypes).Invoke(null)).ToArray();
    }

    void Update()
    {
        if (PowerUpOver())
            Reset();
    }

    public static void SetPowerUp(string tag)
    {
        Reset();
        var powerUps = Powerups.Where(p => p.Tag == tag).ToList();
        if (!powerUps.Any())
            throw new UnityException("Could not find powerup for " + tag);
        if (powerUps.Count() > 1)
            throw new UnityException("Too many powerups found for " + tag);
        var powerup = powerUps.Single();
        powerup.StartPowerup();
        AnimationText.text = powerup.TextForAnimation;
        Animation.Play();
    }

    static void Reset()
    {
        PowerUpStartTime = Time.time;
        IsInvincible = false;
        IsSlow = false;
        IsFast = false;
        IsReverse = false;
    }

    static Type[] AllPowerUps()
    {
        return typeof(PowerUpManager).Assembly.GetTypes();
    }

    static bool IsPowerUp(Type t)
    {
        return typeof(PowerUp).IsAssignableFrom(t) && !t.IsAbstract;
    }

    static bool PowerUpOver()
    {
        var diff = Time.time - PowerUpStartTime;
        var seconds = (int)diff % 60;
        return seconds >= PowerUpTime;
    }
}