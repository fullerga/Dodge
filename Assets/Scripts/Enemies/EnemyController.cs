using UnityEngine;

public class EnemyController
{
    public const float SlowMultiplier = 0.5F;
    public const float FastMultiplier = 2.0F;

    EnemyMovement EnemyMovement;
    Spawner Spawner;
    HealthBar HealthBar;

    public EnemyController(EnemyMovement enemyMovement, Spawner spawner, HealthBar healthbar)
    {
        EnemyMovement = enemyMovement;
        Spawner = spawner;
        HealthBar = healthbar;
    }

    public void Update(GameObject obj, float deltaTime)
    {
        if (IsOutOfView(obj.transform.position))
        {
            GameObject.DestroyImmediate(obj);
            Spawner.EnemyDied();    // TODO move enemy count into some controlled global state
            if (!HealthBar.IsDead())    // TODO health does not make sense to be on a healthbar but instead a player a part of the global state
                GameStats.points++;
        }
        else
        {
            var position = EnemyPosition.FromTransform(obj.transform);
            obj.transform.position += EnemyMovement.PositionTransform(position, deltaTime) * EnemyMovement.speed * GetSpeedMultiplier();
            obj.transform.rotation = EnemyMovement.RotationTransform(position, deltaTime);
        }
    }

    float GetSpeedMultiplier()
    {
        if (PowerUpManager.IsSlow)
            return 0.5F;
        if (PowerUpManager.IsFast)
            return 2F;
        return 1F;
    }

    bool IsOutOfView(Vector3 position)
    {
        return position.x >= WorldCoordinates.LargestDimension || position.x <= -WorldCoordinates.LargestDimension
            || position.y >= WorldCoordinates.LargestDimension || position.y <= -WorldCoordinates.LargestDimension;
    }
}
