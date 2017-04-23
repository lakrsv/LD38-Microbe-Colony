using System;
using UnityEngine;

public class CompartmentColor
{
    public static Color GetCompartmentColor(CompartmentType type)
    {
        switch (type)
        {
            case CompartmentType.Combat:
                return new Color(0xd3, 0x40, 0x2d);
            case CompartmentType.Exploration:
                return new Color(0xb6, 0x2d, 0xd3);
            case CompartmentType.Power:
                return new Color(0xd3, 0xc9, 0x2d);
            case CompartmentType.Resource:
                return new Color(0x2d, 0x5c, 0xd3);
            default:
                throw new ArgumentOutOfRangeException("This compartment type is not implemented");
        }
    }
}
