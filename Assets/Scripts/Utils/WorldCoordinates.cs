using UnityEngine;

public class WorldCoordinates
{
    private static float _screenWidth;
    private static float _screenHeight;
    private static Vector3 _topRightCorner;

    public static float ScreenWidth
    {
        get
        {
            if (_screenWidth == 0)
                _screenWidth = TopRightCorner.x * 2;
            return _screenWidth;
        }
    }

    public static float ScreenHeight
    {
        get
        {
            if (_screenHeight == 0)
                _screenHeight = TopRightCorner.y * 2;
            return _screenHeight;
        }
    }

    /// <summary>
    /// The larger of the ScreenHeight and ScreenWidth in world coordinates
    /// </summary>
    public static float LargestDimension
    {
        get
        {
            return ScreenHeight > ScreenWidth ? ScreenHeight : ScreenWidth;
        }
    }

    private static Vector3 TopRightCorner
    {
        get
        {
            if (_topRightCorner == Vector3.zero)
                _topRightCorner = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            return _topRightCorner;
        }
    }
}
