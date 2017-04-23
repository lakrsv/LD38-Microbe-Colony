using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour, IHarvestable, ISelectable
{
    public ResourceType Type { get; private set; }
    public float Quantity { get; protected set; }

    private void Awake()
    {
        //Register with a Compartment Updater or so
        var resourceName = GetType().ToString();
        gameObject.name = resourceName;
        Type = (ResourceType)Enum.Parse(typeof(ResourceType), resourceName);
    }

    public void SetQuantity(float amount)
    {
        Quantity = amount;
    }

    public float Harvest(float amount)
    {
        float harvested = 0;
        if (Quantity > amount)
        {
            harvested = amount;
        }
        else
        {
            harvested = Quantity;
        }

        Quantity = Mathf.Max(Quantity - amount, 0);
        return harvested;
    }

    public abstract void OnSelect();
}
