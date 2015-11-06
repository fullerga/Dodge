using UnityEngine;

public class bulletMove : MonoBehaviour
{
    HealthBar HealthBar;
    spawnerLevel1 Spawner;

    void Start()
    {

        HealthBar = GameObject.Find("health").GetComponent<HealthBar>();
        Spawner = GameObject.Find("Spawner").GetComponent<spawnerLevel1>();
        var current = transform.position;
        float offset = Random.Range(-30, 30);
        if (current.x < 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg - 90 + offset);
        if (current.x > 0)
            transform.Rotate(Vector3.forward, Mathf.Atan(current.y / current.x) * Mathf.Rad2Deg + 90 + offset);
    }

    void Update()
    {
        var movementSpeed = GetSpeed();
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        const int xRange = 9;
        const int yRange = 9;
        if (transform.position.x > xRange || transform.position.x < -xRange || transform.position.y > yRange || transform.position.y < -yRange)
        {
            Destroy(gameObject);
            Spawner.enemyDied();
            if (!HealthBar.IsDead())
            {
                gameStats.points++;
            }
        }
    }

    float GetSpeed()
    {
        if (PowerUpManager.IsSlow)
            return 1F;
        if (PowerUpManager.IsFast)
            return 3F;
        return 2F;
    }
}
