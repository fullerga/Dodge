using UnityEngine;

public abstract class PositionTest : MonoBehaviour
{
    public int NumUpdates;
    public GameObject GameObject;

    private int currentUpdate;
    private Vector3 previousPosition;

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
                IntegrationTest.Pass(GameObject);
            OnUpdateWithPositions(previousPosition, GetPosition());
            SetPrevious();
        }
        currentUpdate++;
    }

    void SetPrevious()
    {
        previousPosition = GetPosition();
    }

    Vector3 GetPosition()
    {
        return GameObject.transform.position;
    }

    protected abstract void OnUpdateWithPositions(Vector3 previousPosition, Vector3 currentPosition);
}
