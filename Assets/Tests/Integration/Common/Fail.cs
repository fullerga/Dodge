using UnityEngine;

public static class Fail
{
    public static void IfNotZero(float num, GameObject gObject, string variable)
    {
        if (num != 0)
            IntegrationTest.Fail(gObject,
                string.Format("Expected {0} to be 0 but was {1}", variable, num));
    }

    public static void IfNotPositive(float num, GameObject gObject, string variable)
    {
        if (num <= 0)
            IntegrationTest.Fail(gObject,
                string.Format("Expected {0} to be positive but was {1}", variable, num));
    }

    public static void IfNotNegative(float num, GameObject gObject, string variable)
    {
        if (num >= 0)
            IntegrationTest.Fail(gObject,
                string.Format("Expected {0} to be negative but was {1}", variable, num));
    }

    public static void IfNotApproximately(float num, float expected, GameObject gObject)
    {
        if (!Mathf.Approximately(num, expected))
            IntegrationTest.Fail(gObject,
                string.Format("Expected {0} to be approximately equal {1}", num, expected));
    }

    public static void IfNotApproximately(float num, float expected, float threshold, GameObject gObject)
    {
        if (Mathf.Abs(num - expected) > threshold)
            IntegrationTest.Fail(gObject,
                string.Format("Expected {0} to be approximately equal {1}", num, expected));
    }
}
