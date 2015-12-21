using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    EnemyController EnemyController;
    HealthBar HealthBar;
    Spawner Spawner;

    void Start()
    {
        EnemyController = new EnemyController(this, Spawner, HealthBar);
    }

    void Update()
    {
        EnemyController.Update(gameObject, Time.deltaTime);
    }

    public abstract Vector3 PositionTransform(EnemyPosition position, float deltaTime);
    public abstract Vector3 RotationTransform(EnemyPosition position, float deltaTime);
}
