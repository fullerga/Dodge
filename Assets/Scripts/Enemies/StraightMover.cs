using UnityEngine;

public class StraightMover : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }
}
