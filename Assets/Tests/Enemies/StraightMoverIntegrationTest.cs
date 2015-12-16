public class StraightMoverIntegrationTest : PositionDiffTest
{
    protected override void OnUpdateWithDiffs(float diffX, float diffY, float diffZ)
    {
        Fail.IfNotZero(diffX, GameObject, "x");
        Fail.IfNotZero(diffZ, GameObject, "z");
        Fail.IfNotPositive(diffY, GameObject, "y");
    }
}
