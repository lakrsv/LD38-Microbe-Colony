using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour, IHarvestable, ISelectable
{
    public float Quantity { get; protected set; }

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
