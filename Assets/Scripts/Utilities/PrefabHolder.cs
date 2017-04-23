using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : MonoBehaviour
{
    public static PrefabHolder Instance { get { return _instance; } }
    private static PrefabHolder _instance;

    public GameObject TilePrefab;
    public GameObject CompartmentPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("Only one instance of PrefabHolder is allowed!");
            Destroy(gameObject);
            return;
        }
    }
}
