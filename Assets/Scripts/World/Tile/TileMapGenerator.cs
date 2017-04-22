using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a grid of tiles
/// </summary>
public class TileGridGenerator
{
    //Our tile image is 256x256 but our tile sprite is 256x222.
    private float _xPositionOffset = 0.75f;
    private float _yPositionOffset = 0.5f;

    public TileGrid CreateGrid(int width, int height)
    {
        var tileData = new TileData[width, height];

        float tileWidth = 1.0f;
        float tileHeight = (Mathf.Sqrt(3) / 2f) * tileWidth;

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float xOffset = (y % 2) * _xPositionOffset * tileWidth;
                float yOffset = (x % 2) * _yPositionOffset * tileHeight;

                float xPos = x * _xPositionOffset * tileWidth + xOffset;
                float yPos = y * _yPositionOffset * tileHeight - yOffset;

                var position = new Vector2(xPos, yPos);
                var newTileData = new TileData(position);

                tileData[x, y] = newTileData;
            }
        }

        return new TileGrid(width, height, tileData);
    }
}
