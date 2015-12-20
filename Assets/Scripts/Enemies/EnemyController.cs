using UnityEngine;

public class EnemyController
{
    const float movementSpeed = 3F;
    private EnemyMovement EnemyMovement;

    public EnemyController(EnemyMovement enemyMovement)
    {
        EnemyMovement = enemyMovement;
    }

    public void Update(Transform transform, float deltaTime)
    {
        var position = EnemyPosition.FromTransform(transform);
        transform.position += EnemyMovement.PositionTransform(position, deltaTime) * movementSpeed;
        transform.Rotate(EnemyMovement.RotationTransform(position, deltaTime));
    }
}
