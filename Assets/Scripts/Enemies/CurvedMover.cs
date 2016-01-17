using UnityEngine;

public class CurvedMover : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }

    public override Quaternion RotationTransform(EnemyPosition position, float deltaTime)
    {
        return position.Rotation.Rotate(0, 0, 10 * deltaTime);
    }
}
