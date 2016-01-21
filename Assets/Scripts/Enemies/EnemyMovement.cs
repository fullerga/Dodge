using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    EnemyController EnemyController;
    protected Vector3 up;
    public float speed = 1;
    protected Spawner spawner;
    bool fading = false;
    float fadeSpeed = .1F;

    void Start()
    {
        var healthbar = FindGameObject<HealthBar>("health");
        spawner = FindGameObject<RandomSpawner>("spawner");
        EnemyController = new EnemyController(this, spawner, healthbar);
        up = transform.up;
    }

    public virtual void Update()
    {
        EnemyController.Update(gameObject, Time.deltaTime);

        if (fading)
        {
            Color c = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, c.a - fadeSpeed);

            if (c.a <= 0)
                Destroy(gameObject);
        }
    }

    private T FindGameObject<T>(string name)
    {
        var obj = GameObject.Find(name);
        if (obj == null)
            return default(T);
        return obj.GetComponent<T>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
            fading = true;
    }

    public virtual Vector3 PositionTransform(EnemyPosition position, float deltaTime)
    {
        return Vector3.zero;
    }
    public virtual Quaternion RotationTransform(EnemyPosition position, float deltaTime)
    {
        return position.Rotation;
    }
}