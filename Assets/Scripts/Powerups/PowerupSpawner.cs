﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class PowerupSpawner : MonoBehaviour
{
    const int LongestPowerupWaitInSeconds = 40;
    const int CheckEveryNSeconds = 4;

    static List<Object> ActivePowerups;
    static Object PowerupLock = new Object();
    static HealthBar HealthBar;
    static float LastCheckTime;

    public static void ClearActivePowerups()
    {
        lock (PowerupLock)
            ActivePowerups.Clear();
    }

    void Start()
    {
        ActivePowerups = new List<Object>();
        HealthBar = GameObject.Find("health").GetComponent<HealthBar>();
        LastCheckTime = Time.time;
    }

    void Update()
    {
        lock (PowerupLock)
        {
            if (!ActivePowerups.Any() && ShouldSpawnPowerup())
                SpawnPowerup();
        }
    }

    bool ShouldSpawnPowerup()
    {
        if (Time.time - LastCheckTime < CheckEveryNSeconds)
            return false;
        LastCheckTime = Time.time;
        var sinceLastPowerup = Time.time - PowerUpManager.PowerUpEndTime;
        var probability = sinceLastPowerup / LongestPowerupWaitInSeconds;
        return Random.value <= probability;
    }

    void SpawnPowerup()
    {
        SpawnPowerupProbability probability;
        if (HealthBar.HasFullHealth())
            probability = new SpawnPowerupProbability
            {
                FasterEnemy = 0.3F,
                Health = 0,
                PlayerReverse = 0.3F,
                Invincible = 0.1F,
                SlowerEnemy = 0.3F
            };
        else if (HealthBar.HasLowHealth())
            probability = new SpawnPowerupProbability
            {
                FasterEnemy = 0.2F,
                Health = 0.25F,
                PlayerReverse = 0.2F,
                Invincible = 0.15F,
                SlowerEnemy = 0.2F
            };
        else
            probability = new SpawnPowerupProbability
            {
                FasterEnemy = 0.25F,
                Health = 0.15F,
                PlayerReverse = 0.25F,
                Invincible = 0.1F,
                SlowerEnemy = 0.25F
            };
        SpawnWithProbability(probability);
    }

    void SpawnWithProbability(SpawnPowerupProbability probability)
    {
        var powerupPath = GetPowerupResourcePath(probability);
        var pos = new Vector2(Random.value, Random.value);
        pos = Camera.main.ViewportToWorldPoint(pos);
        var powerup = Instantiate(Resources.Load(powerupPath), pos, Quaternion.identity);
        ActivePowerups.Add(powerup);
    }

    string GetPowerupResourcePath(SpawnPowerupProbability p)
    {
        var random = Random.value;
        if (random <= p.FasterEnemy)
            return "Powerups/FasterEnemyPowerup";
        if (random <= p.FasterEnemy + p.Health)
            return "Powerups/HealthPowerup";
        if (random <= p.FasterEnemy + p.Health + p.Invincible)
            return "Powerups/InvinciblePowerup";
        if (random <= p.FasterEnemy + p.Health + p.Invincible + p.PlayerReverse)
            return "Powerups/ReversePowerup";
        return "Powerups/SlowerEnemyPowerup";
    }

    private struct SpawnPowerupProbability
    {
        public float FasterEnemy;
        public float Health;
        public float Invincible;
        public float PlayerReverse;
        public float SlowerEnemy;
    }
}
