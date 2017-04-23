using System;
using System.Reflection;

using System.Collections.Generic;
using UnityEngine;

public class CompartmentController : MonoBehaviour
{
    private Dictionary<CompartmentPosition, GameObject> _compartmentObjects = new Dictionary<CompartmentPosition, GameObject>();
    private Dictionary<GameObject, Compartment> _compartmentScripts = new Dictionary<GameObject, Compartment>();

    private string _compartmentTypeSuffix = "Compartment";

    private void Awake()
    {
        var myTransform = transform;
        for(int i = 0; i < 4; i++)
        {
            var compartmentObj = myTransform.GetChild(i).gameObject;
            _compartmentObjects.Add((CompartmentPosition)i, compartmentObj);
        }
    }

    public bool CreateCompartment(CompartmentType type, CompartmentPosition position)
    {
        var compartmentObj = _compartmentObjects[position];

        if (_compartmentScripts.ContainsKey(compartmentObj))
        {
            Debug.LogWarning("This object already has a compartment!");
            return false;
        }

        var compartmentType = GetCompartmentType(type);
        var compartmentScript = (Compartment)compartmentObj.AddComponent(compartmentType);

        _compartmentScripts.Add(compartmentObj, compartmentScript);

        return true;
    }

    public Compartment GetCompartmentScriptAtPosition(CompartmentPosition position)
    {
        var compartmentObj = _compartmentObjects[position];
        return _compartmentScripts.ContainsKey(compartmentObj) ? _compartmentScripts[compartmentObj] : null;
    }

    private Type GetCompartmentType(CompartmentType type)
    {
        var classname = type.ToString() + _compartmentTypeSuffix;
        var compartmentType = Type.GetType(classname);

        return compartmentType;
    }
}
