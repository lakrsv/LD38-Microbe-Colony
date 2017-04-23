using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IUpdateable {

    protected Colony _colony;

    private void Start()
    {
        EntityTickUpdater.Instance.RegisterCompartment(this);
    }

    public virtual void OnTick()
    {
        Debug.Log(string.Format("Updated Actor {0} of Type {1}", gameObject.name, GetType()));
    }

    public abstract void CreateActor();
    public abstract void DestroyActor();
}
