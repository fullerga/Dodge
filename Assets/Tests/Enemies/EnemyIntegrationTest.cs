using UnityEngine;

public class EnemyIntegrationTest : MonoBehaviour
{

    public EnemyBase Enemy;
    public int NumUpdates;

    private int currentUpdate;
    private float previousX;
    private float previousY;

    void Start()
    {
        currentUpdate = 0;
        SetPrevious();
    }

    void Update()
    {
        if (currentUpdate != 0)
        {
            if (currentUpdate == NumUpdates)
                IntegrationTest.Pass(Enemy.gameObject);

            var xDiff = Enemy.transform.position.x - previousX;
            if (xDiff != 0)
                IntegrationTest.Fail(Enemy.gameObject,
                    string.Format("Expected change in y to always be 0 but was {0}", xDiff));

            var yDiff = Enemy.transform.position.y - previousY;
            if (yDiff <= 0)
                IntegrationTest.Fail(Enemy.gameObject,
                    string.Format("Expected change in y to always be positive but was {0}", yDiff));

            SetPrevious();
        }
        currentUpdate++;
    }

    void SetPrevious()
    {
        previousX = Enemy.transform.position.x;
        previousY = Enemy.transform.position.y;
    }
}
