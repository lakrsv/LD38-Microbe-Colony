using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public Vector2 TilePosition { get; private set; }

    public TileData(Vector2 tilePosition)
    {
        TilePosition = tilePosition;
    }
}
