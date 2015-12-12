using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    protected float movementSpeed = 3F;
    protected HealthBar hb;
    protected Spawner spawner;
    protected Vector3 up;

    protected virtual void Start()
    {
        setObj();
        up = transform.up;
    }
    protected abstract void Update();

    protected void setObj()
    {
        hb = GameObject.Find("health").GetComponent<HealthBar>();
        spawner = GameObject.Find("spawner").GetComponent<RandomSpawner>();
    }

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
