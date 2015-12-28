﻿using UnityEngine;

public class StraightSpinner : EnemyMovement
{
    public const float RotationInDegrees = 2;

    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return new Vector3(0, 0, RotationInDegrees);
    }
}
