using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a grid of tiles
/// </summary>
public class TileGridGenerator
{
    public TileGrid CreateGrid(int width, int height)
    {
        var tileData = new TileData[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var gridPosition = new Point(x, y);
                var newTileData = new TileData(gridPosition);

                tileData[x, y] = newTileData;
            }
        }

        return new TileGrid(width, height, tileData);
    }
}
