using UnityEngine;

public static class HexagonGridHelper
{
    //Our tile image is 256x256 but our tile sprite is 256x222.
    private static float _xPositionOffset = 0.75f;
    private static float _yPositionOffset = 0.5f;

    public static Point[] EvenDirections = new Point[]
    {
        new Point(1, 1),
        new Point(1, 0),
        new Point(0, -1),
        new Point(-1, 0),
        new Point(-1, +1),
        new Point(0, 1)
    };

    public static Point[] OddDirections = new Point[]
    {
        new Point(1, 0),
        new Point(1, -1),
        new Point(0, -1),
        new Point(-1, -1),
        new Point(-1, 0),
        new Point(0, 1)
    };

    public enum HexagonDirection
    {
        TopRight,
        BottomRight,
        Bottom,
        BottomLeft,
        TopLeft,
        Top
    }

    public static Vector2 GridToWorldPosition(Point gridPosition)
    {
        float tileWidth = 1.0f;
        float tileHeight = (Mathf.Sqrt(3) / 2f) * tileWidth;

        float gridX = gridPosition.x;
        float gridY = gridPosition.y;

        float xOffset = 0;
        float yOffset = -(gridX % 2) * _yPositionOffset * tileHeight;

        float xPos = gridX * _xPositionOffset * tileWidth + xOffset;
        float yPos = gridY * tileHeight + yOffset;

        var position = new Vector2(xPos, yPos);
        return position;
    }
}
