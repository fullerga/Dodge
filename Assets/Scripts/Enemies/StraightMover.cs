using UnityEngine;

public class StraightMover : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return Vector3.zero;
    }
}
