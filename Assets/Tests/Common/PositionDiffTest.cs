using UnityEngine;

public abstract class PositionDiffTest : PositionTest
{
    protected override void OnUpdateWithPositions(Vector3 previousPosition, Vector3 currentPosition,
        Quaternion previousRotation, Quaternion currentRotation)
    {
        OnUpdateWithDiffs(currentPosition.x - previousPosition.x,
            currentPosition.y - previousPosition.y,
            currentPosition.z - previousPosition.z, 
            Quaternion.Angle(previousRotation, currentRotation));
    }

    protected abstract void OnUpdateWithDiffs(float diffX, float diffY, float diffZ, float diffRotation);
}
