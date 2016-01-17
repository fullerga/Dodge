using UnityEngine;

public class CurvedSpinner : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        up = Quaternion.Euler(0, 0, .1F) * up;
        return up * deltaTime;
    }

    public override Quaternion RotationTransform(EnemyPosition position, float deltaTime)
    {
        return position.Rotation.Rotate(0, 0, 100 * deltaTime);
    }
}
