using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    const int XCameraRange = 9;
    const int YCameraRange = 9;

    protected HealthBar hb;
    protected Spawner spawner;

    protected Vector3 up;

    protected virtual void Start()
    {
        setObj();

        Vector3 current = transform.position;
        float offset = Random.Range(-30, 30);
        if (current.x < 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg - 90 + offset);
        else
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90 + offset);

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
        return transform.position.x > XCameraRange || transform.position.x < -XCameraRange 
            || transform.position.y > YCameraRange || transform.position.y < -YCameraRange;
    }

    protected void DestroyEnemy()
    {
        Destroy(gameObject);
        spawner.EnemyDied();
        if (!hb.IsDead())
            gameStats.points++;
    }
}
