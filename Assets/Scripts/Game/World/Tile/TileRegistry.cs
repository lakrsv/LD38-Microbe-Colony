using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRegistry
{
    #region Singleton
    public static TileRegistry Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TileRegistry();
            }
            return _instance;
        }
    }
    private static TileRegistry _instance;

    private TileRegistry() { }
    #endregion

    private Tile[,] _tiles;
    private int _tileGridWidth, _tileGridHeight;

    private Dictionary<Tile, Colony> _tileOwners = new Dictionary<Tile, Colony>();

    public void SetTiles(int gridWidth, int gridHeight, Tile[,] tiles)
    {
        if (_tiles == null)
        {
            _tiles = tiles;

            _tileGridWidth = gridWidth;
            _tileGridHeight = gridHeight;
        }
        else
        {
            Debug.LogError("Tiles are already set! This shouldn't happen!");
        }
    }

    public Tile GetTile(Point tileGridPosition)
    {
        int gridX = tileGridPosition.x;
        int gridY = tileGridPosition.y;

        bool inBoundsX = (gridX >= 0 && gridX < _tileGridWidth);
        bool inBoundsY = (gridY >= 0 && gridY < _tileGridHeight);

        if(inBoundsX && inBoundsY)
        {
            return _tiles[gridX, gridY];
        }
        else
        {
            return null;
        }
    }

    public void SetTileOwner(Tile tile, Colony colony)
    {
        Debug.Log(string.Format("Register Colony: {0} as owner of Tile: {1}", colony.name, tile.name));

        if (!_tileOwners.ContainsKey(tile))
        {
            _tileOwners.Add(tile, colony);
        }
        else
        {
            Debug.LogError("That tile already has an owner!");
        }
    }

    public void RemoveTileOwner(Tile tile, Colony colony)
    {
        Debug.Log(string.Format("Unregistered Colony: {0} as owner of Tile: {1}", colony.name, tile.name));

        if (_tileOwners.ContainsKey(tile))
        {
            if(_tileOwners[tile] == colony)
            {
                _tileOwners.Remove(tile);
            }
            else
            {
                Debug.LogError("That colony doesn't own that tile!");
            }
        }
        else
        {
            Debug.LogError("No colony owns that tile!");
        }
    }

    public Colony GetTileOwner(Tile tile)
    {
        return _tileOwners.ContainsKey(tile) ? _tileOwners[tile] : null;
    }

    public static void Reset()
    {
        Debug.LogWarning("Resetting the TileChoreographer!");
        
        if(_instance != null)
        {
            _instance._tiles = null;
            _instance._tileOwners.Clear();
        }
    }
}
