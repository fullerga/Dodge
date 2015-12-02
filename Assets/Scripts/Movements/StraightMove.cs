using UnityEngine;
using System.Collections;

public class StraightMove : EnemyBase {

    protected override void Update()
    {
        float movementSpeed = 2F;
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        if (IsOutOfView())
            DestroyEnemy();
    }
}
