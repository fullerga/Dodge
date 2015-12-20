using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    EnemyController EnemyController;

    void Start()
    {
        EnemyController = new EnemyController(this);
    }

    void Update()
    {
        EnemyController.Update(transform, Time.deltaTime);
    }

    public abstract Vector3 PositionTransform(EnemyPosition position, float deltaTime);
    public abstract Vector3 RotationTransform(EnemyPosition position, float deltaTime);
}
