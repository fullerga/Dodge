using UnityEngine;

public class CurvedMover : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return new Vector3(0, 0, 10 * deltaTime);
    }
}
