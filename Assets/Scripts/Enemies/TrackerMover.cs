using UnityEngine;
using System;

public class TrackerMover : EnemyMovement
{

    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 diff = playerPosition - transform.position;

        float currentAngle = (float)(Mathf.Atan(transform.up.y / transform.up.x) * 180 / Math.PI);
        Debug.Log(transform.up);
        float angleToAim = (float)(Mathf.Atan(diff.y / diff.x) * 180 / Math.PI);

        if (transform.position.x > playerPosition.x)
        {
            angleToAim += 180;
            currentAngle += 180;
        }

        Debug.Log(currentAngle);
        Debug.Log(angleToAim);

        float toMove = currentAngle - angleToAim;

        return new Vector3(0, 0, -toMove/10);
    }
}
