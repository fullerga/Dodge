using UnityEngine;

public static class ExtensionMethods
{
    public static Quaternion Rotate(this Quaternion quat, float x, float y, float z)
    {
        var rotation = new Vector3(x, y, z);
        var currentAngle = quat.eulerAngles;
        return Quaternion.Euler(rotation + currentAngle);
    }
}
