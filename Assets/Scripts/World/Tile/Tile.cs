using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ISelectable
{
    public TileData Data { get; private set; }

    public void Setup(TileData tileData)
    {
        Data = tileData;
    }

    public void OnSelect()
    {
        Debug.Log("Selected: "+gameObject.name);

        HexagonSelect.Instance.Activate(transform.position);
    }
}
