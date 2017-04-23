using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRequirement
{
    private Dictionary<ResourceType, float> _requiredResources = new Dictionary<ResourceType, float>();

    //Prevent creation
    private ResourceRequirement() { }

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

    /// <summary>
    /// Get resource requirements per level for upgrading a specific compartment
    /// </summary>
    /// <param name="type">The compartment to get requirements for</param>
    /// <returns></returns>
    public static ResourceRequirement GetRequirements(CompartmentType type)
    {
        var requirements = new ResourceRequirement();

        switch (type)
        {
            case CompartmentType.Combat:
                requirements.SetRequiredResourceAmount(ResourceType.Cellulose, 1);
                requirements.SetRequiredResourceAmount(ResourceType.Water, 1);
                break;

            case CompartmentType.Exploration:
                requirements.SetRequiredResourceAmount(ResourceType.Oxygen, 1);
                requirements.SetRequiredResourceAmount(ResourceType.Water, 1);
                break;

            case CompartmentType.Power:
                requirements.SetRequiredResourceAmount(ResourceType.Oxygen, 1);
                requirements.SetRequiredResourceAmount(ResourceType.Cellulose, 1);
                break;

            case CompartmentType.Resource:
                requirements.SetRequiredResourceAmount(ResourceType.Oxygen, 0.5f);
                requirements.SetRequiredResourceAmount(ResourceType.Water, 0.5f);
                requirements.SetRequiredResourceAmount(ResourceType.Cellulose, 0.5f);
                break;
        }

        return requirements;
    }
}
