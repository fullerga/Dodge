using UnityEngine;

public class EnemyPosition
{
    public Vector3 Center { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Vector3 Up { get; private set; }
    public Vector3 Right { get; private set; }

    private EnemyPosition(Transform transform)
    {
        Center = transform.position;
        Rotation = transform.rotation;
        Up = transform.up;
        Right = transform.right;
    }

    public static EnemyPosition FromTransform(Transform transform)
    {
        return new EnemyPosition(transform);
    }
}
