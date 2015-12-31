using UnityEngine;

public class HomingEnemy : EnemyMovement
{
    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Right * deltaTime;
    }

    public override Quaternion RotationTransform(EnemyPosition position, float deltaTime)
    {
        var playerPosition = GameObject.Find("player").transform;
        var vectorToTarget = playerPosition.position - position.Center;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        return Quaternion.Slerp(position.Rotation, q, Time.deltaTime);
    }
}