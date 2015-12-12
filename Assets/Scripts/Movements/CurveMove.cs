using UnityEngine;

public class CurveMove : EnemyBase {

    protected override void Update()
    {
        transform.Rotate(0, 0, 10 * Time.deltaTime);

        transform.position += transform.up * Time.deltaTime * movementSpeed;
        if (IsOutOfView())
            DestroyEnemy();
    }
}
