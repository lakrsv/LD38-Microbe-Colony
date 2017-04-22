using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    [SerializeField]
    private GameObject _tilePrefab;

    private Tile[,] _tiles;

	// Use this for initialization
	void Start ()
    {
        CreateWorld();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void CreateWorld()
    {
        var tileMapGenerator = new TileGridGenerator();
        var tileGrid = tileMapGenerator.CreateGrid(10, 10);
        
        for (int i = 0; i < tileGrid.Width; i++)
        {
            for (int k = 0; k < tileGrid.Height; k++)
            {
                var tileData = tileGrid.TileData[i, k];
                var tileWorldPosition = GridPositionConverter.GridToWorldPosition(tileData.TileGridPosition);

                var tile = Instantiate(_tilePrefab, tileWorldPosition, Quaternion.identity);
                tile.name = string.Format("Tile: {0},{1}", i, k);

                var tileScript = tile.GetComponent<Tile>();
                tileScript.Setup(tileData);
            }
        }
    }
}
