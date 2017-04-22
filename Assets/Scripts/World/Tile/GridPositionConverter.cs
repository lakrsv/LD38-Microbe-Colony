using UnityEngine;

public static class GridPositionConverter
{
    //Our tile image is 256x256 but our tile sprite is 256x222.
    private static float _xPositionOffset = 0.75f;
    private static float _yPositionOffset = 0.5f;

    public static Vector2 GridToWorldPosition(Point gridPosition)
    {
        float tileWidth = 1.0f;
        float tileHeight = (Mathf.Sqrt(3) / 2f) * tileWidth;

        float x = gridPosition.x;
        float y = gridPosition.y;

        float xOffset = (y % 2) * _xPositionOffset * tileWidth;
        float yOffset = (x % 2) * _yPositionOffset * tileHeight;

        float xPos = x * _xPositionOffset * tileWidth + xOffset;
        float yPos = y * _yPositionOffset * tileHeight - yOffset;

        var position = new Vector2(xPos, yPos);
        return position;
    }
}
