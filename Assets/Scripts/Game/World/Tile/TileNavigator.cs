using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNavigator : MonoBehaviour
{
    public static Tile GetNeighbourTile(Tile tile, HexagonGridHelper.HexagonDirection direction)
    {
        var tileGridPos = tile.Data.TileGridPosition;
        bool isEven = tileGridPos.x % 2 == 0;
        var directions = isEven ? HexagonGridHelper.EvenDirections : HexagonGridHelper.OddDirections;

        var neighbourGridX = tileGridPos.x + directions[(int)direction].x;
        var neighbourGridY = tileGridPos.y + directions[(int)direction].y;
        var neighbourGridPosition = new Point(neighbourGridX, neighbourGridY);

        var neighbourTile = TileRegistry.Instance.GetTile(neighbourGridPosition);

        return neighbourTile;
    }
}
