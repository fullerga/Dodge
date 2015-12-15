using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    public HealthBar hb;
    public Spawner spawner;
    protected float movementSpeed = 3F;
    protected Vector3 up;

    protected virtual void Start()
    {
        up = transform.up;
    }
    protected abstract void Update();

    private float GetSpeedMultiplier()
    {
        if (PowerUpManager.IsSlow)
            return 0.5F;
        if (PowerUpManager.IsFast)
            return 2F;
        return 1F;
    }

    protected bool IsOutOfView()
    {
        return transform.position.x > WorldCoordinates.LargestDimension || transform.position.x < -WorldCoordinates.LargestDimension
            || transform.position.y > WorldCoordinates.LargestDimension || transform.position.y < -WorldCoordinates.LargestDimension;
    }

    protected void DestroyEnemy()
    {
        Destroy(gameObject);
        spawner.EnemyDied();
        if (!hb.IsDead())
            gameStats.points++;
    }
}
