using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private Dictionary<ResourceType, GameObject> _resourceIcons = new Dictionary<ResourceType, GameObject>();

    public Resource Resource { get; private set; }

    private void Awake()
    {
        var myTransform = transform;
        for(int i = 0; i < 3; i++)
        {
            var iconObj = myTransform.GetChild(i).gameObject;
            _resourceIcons.Add((ResourceType)i, iconObj);
            iconObj.SetActive(false);
        }
    }

    public void CreateResource(ResourceType type, float quantity)
    {
        if(Resource != null)
        {
            Debug.LogError("This Container already contains a resource!");
            return;
        }

        _resourceIcons[type].SetActive(true);

        var resourceType = GetResourceType(type);
        var resourceScript = (Resource)gameObject.AddComponent(resourceType);

        resourceScript.SetQuantity(quantity);

        Resource = resourceScript;
    }

    private Type GetResourceType(ResourceType type)
    {
        var classname = type.ToString();
        var compartmentType = Type.GetType(classname);

        return compartmentType;
    }
}
