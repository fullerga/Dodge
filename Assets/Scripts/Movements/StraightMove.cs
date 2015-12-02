using UnityEngine;
using System.Collections;

public class StraightMove : EnemyBase {

    protected override void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        if (IsOutOfView())
            DestroyEnemy();
    }
}
