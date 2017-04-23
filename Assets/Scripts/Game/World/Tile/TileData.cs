using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public Point TileGridPosition { get; private set; }

    public TileData(Point tileGridPosition)
    {
        TileGridPosition = tileGridPosition;
    }
}
