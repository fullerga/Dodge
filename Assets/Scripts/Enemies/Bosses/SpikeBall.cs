using UnityEngine;

public class SpikeBall : EnemyMovement
{

    float timer = 0;

    public override Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return position.Up * deltaTime;
    }

    public override Vector3 RotationTransform(EnemyPosition position, float deltaTime)
    {
        return Vector3.zero;
    }

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if (timer>=3)
        {
            shootSpikes();
            timer = -50;
        }
    }

    void shootSpikes()
    {
        Quaternion tempRot = transform.rotation;
        Vector3 tempAdj = transform.position.normalized;

        for(int i=0; i<8; i++)
        {
            Instantiate(Resources.Load("enemies/spike"), transform.position+(tempRot*tempAdj), tempRot);
            tempRot *= Quaternion.Euler(new Vector3(0, 0, 45));
        }

        EnemyController.getSpawner().enemyCreated(8);
        Instantiate(Resources.Load("enemies/ballNoSpikes"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
