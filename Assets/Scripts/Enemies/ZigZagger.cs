﻿using UnityEngine;
using System;

public class ZigZagger : EnemyMovement
{
    public const float SecondsToSwitch = 1;

    const float ZigZagLength = 1F;
    float TimeSinceLastChange;
    int moveRight = 1;

    public ZigZagger()
    {
        TimeSinceLastChange = 0;
    }

    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        var x = position.Up * deltaTime;
        var t = x + (Vector3.right * Time.deltaTime * ZigZagLength * moveRight);
        TimeSinceLastChange += deltaTime;
        if (TimeSinceLastChange >= SecondsToSwitch)
        {
            TimeSinceLastChange = 0;
            moveRight = -moveRight;
        }
        return t;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return Vector3.zero;
    }
}