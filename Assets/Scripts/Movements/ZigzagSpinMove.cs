using UnityEngine;
using System.Collections;

public class ZigzagSpinMove : EnemyBase
{

    float zigzagSize = 1F;
    float limit = 1;
    float total = 0;
    float rotationSpeed = 2;
    int moveRight = 1;

    Vector3 right;

    protected override void Start()
    {
        base.Start();

        right = new Vector3(-up.x, up.y, up.z);
    }

    protected override void Update()
    {
        transform.position += up * Time.deltaTime * movementSpeed;
        transform.Translate(right * Time.deltaTime * zigzagSize* moveRight);
        transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.World);

        total += Time.deltaTime;
        if (total >= limit)
        {
            total = 0;
            right = new Vector3(-up.x, -up.y, up.z);
        }
        if (IsOutOfView())
            DestroyEnemy();
    }
}
