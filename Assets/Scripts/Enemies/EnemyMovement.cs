using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    EnemyController EnemyController;
    protected Vector3 up;

    void Start()
    {
        var healthbar = FindGameObject<HealthBar>("health");
        var spawner = FindGameObject<RandomSpawner>("spawner");
        EnemyController = new EnemyController(this, spawner, healthbar);
        up = transform.up;
    }

    void Update()
    {
        EnemyController.Update(gameObject, Time.deltaTime);
    }

    private T FindGameObject<T>(string name)
    {
        var obj = GameObject.Find(name);
        if (obj == null)
            return default(T);
        return obj.GetComponent<T>();
    }

    public abstract Vector3 PositionTransform(EnemyPosition position, float deltaTime);
    public abstract Vector3 RotationTransform(EnemyPosition position, float deltaTime);
}
