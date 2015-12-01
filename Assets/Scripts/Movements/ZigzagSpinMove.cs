using UnityEngine;
using System.Collections;

public class ZigzagSpinMove : EnemyBase
{

    float zigzagSize = 1F;
    float limit = 1;
    float total = 0;
    float rotationSpeed = 2;

    Vector3 right;

    protected override void Start()
    {
        base.Start();

        right = new Vector3(-up.x, up.y, up.z);
    }

    protected override void Update()
    {
        float movementSpeed = 2F;
        transform.position += up * Time.deltaTime * movementSpeed;
        transform.position += right * Time.deltaTime * zigzagSize;
        transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.World);


        total += Time.deltaTime;
        if (total >= limit)
        {
            total = 0;

            right = new Vector3(-right.x, -right.y, up.z);
        }

        if (IsOutOfView())
            DestroyEnemy();
    }
}
