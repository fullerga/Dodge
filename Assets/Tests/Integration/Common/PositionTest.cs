using UnityEngine;

public abstract class PositionTest : MonoBehaviour
{
    public int NumUpdates;
    public GameObject GameObject;

    int currentUpdate;
    Vector3 previousPosition;
    Quaternion previousRotation;


    void Start()
    {
        currentUpdate = 0;
        SetPrevious();
    }

    void Update()
    {
        if (currentUpdate > 5)
        {
            //print(GetPosition());
            if (currentUpdate == NumUpdates)
                IntegrationTest.Pass(GameObject);
            OnUpdateWithPositions(previousPosition, GetPosition(), previousRotation, GetRotation());
            SetPrevious();
        }
        currentUpdate++;
    }

    void SetPrevious()
    {
        previousPosition = GetPosition();
        previousRotation = GetRotation();
    }

    Vector3 GetPosition()
    {
        return GameObject.transform.position;
    }

    Quaternion GetRotation()
    {
        return GameObject.transform.rotation;
    }

    protected abstract void OnUpdateWithPositions(Vector3 previousPosition, Vector3 currentPosition,
        Quaternion previousRotation, Quaternion currentRotation);
}
