using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ISelectable, IClaimable
{
    public TileData Data { get; private set; }
    public CompartmentController CompartmentController { get; private set; }
    public ResourceController ResourceContainer { get; private set; }

    private Visibility _visibility = Visibility.Invisible;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetVisibility(_visibility);
    }

    public void SetVisibility(Visibility visibility)
    {
        if(visibility >= _visibility)
        {
            _visibility = visibility;

            //TODO - Set Properties related to visibility
            //Temporary - Just tint the Color.
            var currentTileColor = _renderer.color;
            var tint = ((int)visibility * (1 / 3f));
            var newTileColor = new Color(tint, tint, tint);

            _renderer.color = newTileColor;
        }
        else
        {
            Debug.LogWarning("Can't decrease visibility of tile!");
        }
    }

    private void SetVisibilityOfSurroundingTiles(Visibility visibility)
    {
        var gridPos = Data.TileGridPosition;
        bool isEven = gridPos.x % 2 == 0;
        var directions = isEven ? HexagonGridHelper.EvenDirections : HexagonGridHelper.OddDirections;

        for(int i = 0; i < directions.Length; i++)
        {
            var direction = directions[i];
            var neighbourGridPosition = new Point(gridPos.x + direction.x, gridPos.y + direction.y);
            var neighbour = TileRegistry.Instance.GetTile(neighbourGridPosition);

            if(neighbour != null)
            {
                neighbour.SetVisibility(visibility);
                if(visibility -1 > Visibility.Invisible)
                {
                    neighbour.SetVisibilityOfSurroundingTiles(visibility - 1);
                }
            }
        }
    }

    public void Setup(TileData tileData)
    {
        Data = tileData;
    }

    public void Claim(Colony colony)
    {
        TileRegistry.Instance.SetTileOwner(this, colony);

        if (colony.IsPlayer)
        {
            SetVisibility(Visibility.Visible);
            SetVisibilityOfSurroundingTiles(Visibility.Visible);
        }

        SetTileType(colony);
        AddCompartmentController();

    }

    public void Unclaim(Colony colony)
    {
        TileRegistry.Instance.RemoveTileOwner(this, colony);
    }

    public void CreateDefaultCompartments()
    {
        if(CompartmentController == null)
        {
            Debug.LogError("This tile doesn't have a compartment controller! Is the tile not claimed?");
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            CompartmentController.CreateCompartment((CompartmentType)i, (CompartmentPosition)i);
        }
    }

    private void SetTileType(Colony colony)
    {
        //TODO - Implement setting tile to represent the colony residing here.
        if(colony is BacteriaColony)
        {
            //TODO - Set Renderer Sprite To Colony Sprite.
            _renderer.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    private void AddCompartmentController()
    {
        var compartmentObj = Instantiate(PrefabHolder.Instance.CompartmentPrefab, transform);
        CompartmentController = compartmentObj.GetComponent<CompartmentController>();
    }

    public void OnSelect()
    {
        Debug.Log("Selected: " + gameObject.name);

        //Debug Visibility
        SetVisibility(Visibility.Visible);
        SetVisibilityOfSurroundingTiles(Visibility.LightFog);

        HexagonSelect.Instance.Activate(transform.position);
    }
}
