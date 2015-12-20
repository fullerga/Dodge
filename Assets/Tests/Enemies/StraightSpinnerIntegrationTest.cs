using UnityEngine;

public class StraightSpinnerIntegrationTest : PositionDiffTest
{
    protected override void OnUpdateWithDiffs(float diffX, float diffY, float diffZ, float diffRotation)
    {
        Fail.IfNotZero(diffX, GameObject, "x");
        Fail.IfNotZero(diffZ, GameObject, "z");
        Fail.IfNotPositive(diffY, GameObject, "y");
        Fail.IfNotPositive(diffRotation, GameObject, "rotation");
    }
}
