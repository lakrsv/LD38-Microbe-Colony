using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Colony : MonoBehaviour
{
    protected string _name;

    protected Tile _homeTile;
    protected List<Tile> _controlledTiles = new List<Tile>();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ClaimTile(Tile tile)
    {
        if(_controlledTiles.Count == 0)
        {
            //This is the first tile of this colony. It is home!
            _homeTile = tile;
        }

        if (!_controlledTiles.Contains(tile))
            _controlledTiles.Add(tile);
        else
            Debug.LogWarning("That colony already owns that tile!");
    }

    public void UnclaimTile(Tile tile)
    {
        if (_controlledTiles.Contains(tile))
            _controlledTiles.Remove(tile);
        else
            Debug.LogWarning("That colony does not own that tile!");

        if(_controlledTiles.Count == 0)
        {
            DestroyColony();
        }
    }

    protected abstract void DestroyColony();
}
