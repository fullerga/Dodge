using UnityEngine;

public class EnemyPosition
{
    public Vector3 Center { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Vector3 Up { get; private set; }

    private EnemyPosition(Vector3 center, Quaternion rotation, Vector3 up)
    {
        Center = center;
        Rotation = rotation;
        Up = up;
    }

    public static EnemyPosition FromTransform(Transform transform)
    {
        return new EnemyPosition(transform.position, transform.rotation, transform.up);
    }
}
