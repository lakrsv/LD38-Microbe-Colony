using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public TileData[,] TileData { get; private set; }

    public TileGrid(int width, int height, TileData[,] tData)
    {
        Width = width;
        Height = height;

        TileData = tData;
    }
}
