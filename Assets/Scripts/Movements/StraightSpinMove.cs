using UnityEngine;
using System.Collections;

public class StraightSpinMove : EnemyBase
{

    public const float RotationInDegrees = 2;

    protected override void Update()
    {
        transform.position += up * Time.deltaTime * movementSpeed;
        transform.Rotate(new Vector3(0, 0, RotationInDegrees), Space.World);
        if (IsOutOfView())
            DestroyEnemy();
    }
}
