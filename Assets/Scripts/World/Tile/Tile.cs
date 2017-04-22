using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ISelectable
{
    public void OnSelect()
    {
        Debug.Log("Selected: "+gameObject.name);
    }

    // Use this for initialization
    void Start()
    {

    }
}
