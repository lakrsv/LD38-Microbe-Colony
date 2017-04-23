using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public override void OnTick()
    {
        //First Tick. Example
        if(EntityTickUpdater.Instance.CurrentTick == 0)
        {
        }

        base.OnTick();
    }

    public override void CreateActor()
    {
        gameObject.name = "Player Controller";

        _colony = gameObject.AddComponent<BacteriaColony>();
        _colony.IsPlayer = true;

        var startTile = TileRegistry.Instance.GetTile(new Point(25, 25));

        _colony.ClaimTile(startTile);
        _colony.SetDefaults();
    }

    public override void DestroyActor()
    {
        throw new NotImplementedException();
    }
}
