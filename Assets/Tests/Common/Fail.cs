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
}
