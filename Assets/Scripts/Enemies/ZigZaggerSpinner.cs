using UnityEngine;
using System;

public class ZigZaggerSpinner : EnemyMovement
{
    public const float SecondsToSwitch = 1;

    const float ZigZagLength = 1F;
    float TimeSinceLastChange;
    int Direction;

    public ZigZaggerSpinner()
    {
        TimeSinceLastChange = 0;
        Direction = 1;
        
    }

    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        Vector3 right = new Vector3(up.y, -up.x, 0);
        Vector3 x = up * deltaTime;
        Vector3 t = x + (right * Time.deltaTime * ZigZagLength * Direction);
        TimeSinceLastChange += deltaTime;
        if (TimeSinceLastChange >= SecondsToSwitch)
        {
            TimeSinceLastChange = 0;
            Direction = -Direction;
        }
        return t;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return new Vector3(0, 0, 100 * deltaTime);
    }
}
