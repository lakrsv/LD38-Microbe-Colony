using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public bool CanExpand = true;
    public int PooledAmount = 20;
    public GameObject PooledObject;

    public List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (var i = 0; i < PooledAmount; i++)
        {
            var obj = Instantiate(PooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);

            obj.name = string.Format("{0}-{1}", PooledObject.name, i);
        }
    }

    public GameObject GetPooledObject()
    {
        for (var i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i] == null)
            {
                var obj = Instantiate(PooledObject);
                obj.SetActive(false);
                pooledObjects[i] = obj;
                return pooledObjects[i];
            }
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        if (CanExpand)
        {
            var obj = Instantiate(PooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}