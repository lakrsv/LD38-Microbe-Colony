using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Colony : MonoBehaviour
{
    public bool IsPlayer;

    protected string _name;
    protected Tile _homeTile;
    protected List<Tile> _controlledTiles = new List<Tile>();

    public void ClaimTile(Tile tile)
    {
        if (_controlledTiles.Count == 0)
        {
            //This is the first tile of this colony. It is home!
            _homeTile = tile;
        }

        if (!_controlledTiles.Contains(tile))
        {
            _controlledTiles.Add(tile);
        }
        else
        {
            Debug.LogWarning("That colony already owns that tile!");
            return;
        }

        tile.Claim(this);
        OnTileClaimed(tile);
    }

    public void UnclaimTile(Tile tile)
    {
        if (_controlledTiles.Contains(tile))
        {
            _controlledTiles.Remove(tile);
        }
        else
        {
            Debug.LogWarning("That colony does not own that tile!");
            return;
        }

        tile.Unclaim(this);
        OnTileUnclaimed(tile);

        if (_controlledTiles.Count == 0)
        {
            DestroyColony();
        }
    }

    public void SetDefaults()
    {
        _homeTile.CreateDefaultCompartments();
        CreateHomeResources();
    }

    private void CreateHomeResources()
    {
        //Power/Expansion Resources close to the Resource center for quick harvest.
        var celluloseTile = TileNavigator.GetNeighbourTile(_homeTile, HexagonGridHelper.HexagonDirection.BottomRight);
        var oxygenTile = TileNavigator.GetNeighbourTile(_homeTile, HexagonGridHelper.HexagonDirection.Bottom);
        //Opposite side.. why not
        var waterTile = TileNavigator.GetNeighbourTile(_homeTile, HexagonGridHelper.HexagonDirection.TopLeft);

        celluloseTile.AddResource(ResourceType.Cellulose, 10);
        oxygenTile.AddResource(ResourceType.Oxygen, 10);
        waterTile.AddResource(ResourceType.Water, 10);
    }

    protected abstract void OnTileClaimed(Tile tile);
    protected abstract void OnTileUnclaimed(Tile tile);

    protected abstract void DestroyColony();
}
