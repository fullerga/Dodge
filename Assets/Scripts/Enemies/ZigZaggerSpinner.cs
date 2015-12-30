using UnityEngine;
using System;

public class ZigZaggerSpinner : ZigZagger
{
    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return new Vector3(0, 0, 100 * deltaTime);
    }
}
