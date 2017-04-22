using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyController : MonoBehaviour
{
    protected Colony _colony { get; private set; }

    private void Awake()
    {
        _colony = GetComponent<Colony>();
    }
}
