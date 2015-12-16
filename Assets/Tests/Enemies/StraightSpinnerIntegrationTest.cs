using UnityEngine;

public class StraightSpinnerIntegrationTest : PositionDiffTest
{
    Quaternion previousRotation;

    void Start()
    {
        previousRotation = Quaternion.identity;
    }

    protected override void OnUpdateWithDiffs(float diffX, float diffY, float diffZ)
    {
        Fail.IfNotZero(diffX, GameObject, "x");
        Fail.IfNotZero(diffZ, GameObject, "z");
        Fail.IfNotPositive(diffY, GameObject, "y");
        var currentRotation = GameObject.transform.rotation;
        var rotation = Quaternion.Angle(previousRotation, currentRotation);
        previousRotation = currentRotation;
        Fail.IfNotPositive(rotation, GameObject, "rotation");
    }
}
