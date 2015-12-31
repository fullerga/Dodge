using UnityEngine;

public class ZigZaggerSpinner : ZigZagger
{
    public override Quaternion RotationTransform(EnemyPosition position, float deltaTime)
    {
        return position.Rotation.Rotate(0, 0, 100 * deltaTime);
    }
}