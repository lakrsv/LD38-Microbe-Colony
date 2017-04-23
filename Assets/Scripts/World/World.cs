using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{


    [SerializeField]
    private int _worldWidth = 11, _worldHeight = 11;
    [SerializeField]
    private GameObject _tilePrefab;

    private List<Colony> _colonies = new List<Colony>();

    private Player _playerActor;
    private List<Actor> _npcActors = new List<Actor>();

    private void Awake()
    {
        TileRegistry.Reset();
    }

    // Use this for initialization
    void Start ()
    {
        CreateTiles();
        CreatePlayer();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void CreateTiles()
    {
        var tileMapGenerator = new TileGridGenerator();
        var tileGrid = tileMapGenerator.CreateGrid(_worldWidth, _worldHeight);
        var tiles = new Tile[_worldWidth, _worldHeight];
        
        for (int i = 0; i < tileGrid.Width; i++)
        {
            for (int k = 0; k < tileGrid.Height; k++)
            {
                var tileData = tileGrid.TileData[i, k];
                var tileWorldPosition = HexagonGridHelper.GridToWorldPosition(tileData.TileGridPosition);

                var tile = Instantiate(_tilePrefab, tileWorldPosition, Quaternion.identity);
                tile.name = string.Format("Tile: {0},{1}", i, k);

                var tileScript = tile.GetComponent<Tile>();
                tileScript.Setup(tileData);

                tiles[i, k] = tileScript;
            }
        }

        TileRegistry.Instance.SetTiles(_worldWidth, _worldHeight, tiles);
    }

    private void CreatePlayer()
    {
        var player = new GameObject();
        _playerActor = player.AddComponent<Player>();
        _playerActor.CreateActor();
    }
}
