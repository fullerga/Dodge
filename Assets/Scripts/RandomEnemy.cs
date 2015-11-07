using UnityEngine;

public class RandomEnemy : EnemyBase
{
    protected override HealthBar HealthBar
    {
        get { return GameObject.Find("health").GetComponent<HealthBar>(); }
    }

    protected override Spawner Spawner
    {
        get { return GameObject.Find("Spawner").GetComponent<spawnerLevel1>(); }
    }

    protected override float GetMovementSpeed()
    {
        return 2F;
    }

    protected override Vector3 GetMovementDirection()
    {
        return transform.up;
    }

    protected override void OnStart()
    {
    }

    protected override void OnUpdate()
    {
    }
}
