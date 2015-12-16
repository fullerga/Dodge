public class CurvedMoverIntegrationTest : PositionDiffTest
{
    protected override void OnUpdateWithDiffs(float diffX, float diffY, float diffZ)
    {
        Fail.IfNotNegative(diffX, GameObject, "x");
        Fail.IfNotPositive(diffY, GameObject, "y");
        Fail.IfNotZero(diffZ, GameObject, "z");
    }
}
