using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    const int XCameraRange = 9;
    const int YCameraRange = 9;

    protected abstract HealthBar HealthBar { get; }
    protected abstract Spawner Spawner { get; }
    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract float GetMovementSpeed();
    protected abstract Vector3 GetMovementDirection();

    void Start()
    {
        OnStart();
        var current = transform.position;
        float offset = Random.Range(-30, 30);
        if (current.x < 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg - 90 + offset);
        if (current.x > 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90 + offset);
    }


    void Update()
    {
        OnUpdate();
        transform.position += GetMovementDirection() * Time.deltaTime * GetMovementSpeed() * GetSpeedMultiplier();
        if (IsOutOfView())
            DestroyEnemy();
    }

    private float GetSpeedMultiplier()
    {
        if (PowerUpManager.IsSlow)
            return 0.5F;
        if (PowerUpManager.IsFast)
            return 2F;
        return 1F;
    }

    private bool IsOutOfView()
    {
        return transform.position.x > XCameraRange || transform.position.x < -XCameraRange 
            || transform.position.y > YCameraRange || transform.position.y < -YCameraRange;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        Spawner.EnemyDied();
        if (!HealthBar.IsDead())
            gameStats.points++;
    }
}
