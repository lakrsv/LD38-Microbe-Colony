using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tile.Old
{
    public class TilePlacer : MonoBehaviour
    {
        private float _xIncrement = 1f;
        private float _yIncrement = 0.25f;

        [SerializeField]
        private GameObject _tileObj;
        [SerializeField]
        private GameObject _tileObj2;

        private TileMap _tileMap;

        // Use this for initialization
        void Start()
        {
            _tileMap = GetComponent<TileMap>();
            _tileMap.PopulateGrid(_tileObj2);
        }

        // Update is called once per frame
        void Update()
        {
            //HandleMouse();
        }

        void HandleMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                var worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                float xRaw = worldMousePosition.x;
                float yRaw = worldMousePosition.y;

                int xDist = Mathf.RoundToInt(xRaw / _xIncrement);
                int yDist = Mathf.RoundToInt(yRaw / _yIncrement);

                float xPos = xDist * _xIncrement;
                float yPos = yDist * _yIncrement;

                Debug.Log(xDist);
                Debug.Log(yDist);

                var tileGameObj = Instantiate(_tileObj);
                tileGameObj.transform.position = new Vector2(xPos, yPos);

                int sortOrder = Mathf.RoundToInt((yPos * -1) * 100);
                tileGameObj.GetComponent<SpriteRenderer>().sortingOrder = sortOrder;
            }
        }
    }
}