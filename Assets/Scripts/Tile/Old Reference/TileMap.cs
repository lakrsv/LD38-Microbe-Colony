using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tile.Old
{
    public class TileMap : MonoBehaviour
    {
        private const int _gridWidth = 10;
        private const int _gridHeight = 10;
        private int[,] _tileGrid = new int[_gridWidth, _gridHeight];

        private float _xModY = 0.75f;
        private float _yModX = -0.433f;
        private float _xIncrement = 0.75f;
        private float _yIncrement = 0.4333f;

        // Use this for initialization
        void Start()
        {
            ResetGrid();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PopulateGrid(GameObject tileObj)
        {
            for (int i = 0; i < _gridWidth; i++)
                for (int k = 0; k < _gridHeight; k++)
                    PlaceTile(i, k, tileObj);
        }

        public bool PlaceTile(int x, int y, GameObject tilePrefab)
        {
            if (_tileGrid[x, y] != 0)
                return false;

            float xOffset = (y % 2) * _xModY;
            float yOffset = (x % 2) * _yModX;
            float xPos = x * _xIncrement + xOffset;
            float yPos = y * _yIncrement + yOffset;

            var tile = Instantiate(tilePrefab);
            tile.transform.position = new Vector2(xPos, yPos);
            tile.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(yPos * 1f * 100f);

            return true;
        }

        private void ResetGrid()
        {
            for (int i = 0; i < _gridWidth; i++)
                for (int k = 0; k < _gridHeight; k++)
                    _tileGrid[i, k] = 0;
        }
    }
}