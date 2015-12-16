using UnityEngine;

public abstract class PositionDiffTest : PositionTest
{
    protected override void OnUpdateWithPositions(Vector3 previousPosition, Vector3 currentPosition)
    {
        OnUpdateWithDiffs(currentPosition.x - previousPosition.x,
            currentPosition.y - previousPosition.y,
            currentPosition.z - previousPosition.z);
    }

    protected abstract void OnUpdateWithDiffs(float diffX, float diffY, float diffZ);
}
