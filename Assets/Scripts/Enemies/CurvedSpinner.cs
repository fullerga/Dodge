using UnityEngine;

public class CurvedSpinner : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        up = Quaternion.Euler(0, 0, .1F) * up;
        return up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return new Vector3(0, 0, 100 * deltaTime);
    }
}
