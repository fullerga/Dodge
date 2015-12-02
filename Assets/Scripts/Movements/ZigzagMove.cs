using UnityEngine;
using System.Collections;

public class ZigzagMove : EnemyBase
{

    float zigzagSize = 1F;
    float limit = 1;
    float total = 0;
    int moveRight = 1;

    protected override void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        transform.Translate(Vector3.right * Time.deltaTime * zigzagSize*moveRight);

        total += Time.deltaTime;
        if (total >= limit)
        {
            total = 0;
            moveRight = -moveRight;
        }

        if (IsOutOfView())
            DestroyEnemy();
    }
}
