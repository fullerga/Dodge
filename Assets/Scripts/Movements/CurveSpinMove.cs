using UnityEngine;
using System.Collections;

public class CurveSpinMove : EnemyBase
{

    float rotationSpeed = 2;
    float curveSize = .1F;

    protected override void Update()
    {
        up = Quaternion.Euler(0, 0, curveSize) * up;

        transform.position += up * Time.deltaTime * movementSpeed;
        transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.World);

        if (IsOutOfView())
            DestroyEnemy();
    }
}
