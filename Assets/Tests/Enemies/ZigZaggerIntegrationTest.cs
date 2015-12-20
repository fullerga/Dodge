using UnityEngine;

public class ZigZaggerIntegrationTest : PositionDiffTest
{
    float totalTime;
    bool isPositiveDiff;

    void Start()
    {
        totalTime = 0;
        isPositiveDiff = true;
    }

    protected override void OnUpdateWithDiffs(float diffX, float diffY, float diffZ, float diffRotation)
    {
        totalTime += Time.deltaTime;
        if(diffX > 0 && !isPositiveDiff)
            CheckTime();

        if (diffX < 0 && isPositiveDiff)
            CheckTime();

        Fail.IfNotZero(diffZ, GameObject, "z");
        Fail.IfNotPositive(diffY, GameObject, "y");
    }

    void CheckTime()
    {
        Fail.IfNotApproximately(totalTime, ZigZagger.SecondsToSwitch, 0.1F, GameObject);
        totalTime = 0;
        isPositiveDiff = !isPositiveDiff;
    }
}
