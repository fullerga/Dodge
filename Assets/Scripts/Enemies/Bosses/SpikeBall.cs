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
        Quaternion tempPos = new Quaternion(0, 0, 1, 0);
        Vector3 tempAdj = transform.up;

        for(int i=0; i<8; i++)
        {
            Debug.Log(tempPos * tempAdj);
            Instantiate(Resources.Load("enemies/spike"), transform.position-(tempPos*tempAdj), tempRot);
            tempRot *= Quaternion.Euler(0, 0, 45);
            tempPos *= Quaternion.Euler(0, 0, 45);
        }

        EnemyController.getSpawner().enemyCreated(8);
        Instantiate(Resources.Load("enemies/ballNoSpikes"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
