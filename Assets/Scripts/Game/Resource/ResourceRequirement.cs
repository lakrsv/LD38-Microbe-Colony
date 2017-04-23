using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRequirement
{
    private Dictionary<ResourceType, float> _requiredResources = new Dictionary<ResourceType, float>();

    public void SetRequiredResourceAmount(ResourceType type, float amount)
    {
        if(!_requiredResources.ContainsKey(type))
        _requiredResources.Add(type, amount);
    }

    public float GetRequiredResourceAmount(ResourceType type)
    {
        if (_requiredResources.ContainsKey(type))
        {
            return _requiredResources[type];
        }

        return 0;
    }
}
