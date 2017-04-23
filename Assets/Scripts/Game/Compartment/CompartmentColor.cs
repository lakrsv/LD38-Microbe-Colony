using System;
using UnityEngine;

public class CompartmentColor
{
    public static Color GetCompartmentColor(CompartmentType type)
    {
        switch (type)
        {
            case CompartmentType.Combat:
                return new Color(0xd3 / 255f, 0x40 / 255f, 0x2d / 255f);
            case CompartmentType.Exploration:
                return new Color(0xb6 / 255f, 0x2d / 255f, 0xd3 / 255f);
            case CompartmentType.Power:
                return new Color(0xd3 / 255f, 0xc9 / 255f, 0x2d / 255f);
            case CompartmentType.Resource:
                return new Color(0x2d / 255f, 0x5c / 255f, 0xd3 / 255f);
            default:
                throw new ArgumentOutOfRangeException("This compartment type is not implemented");
        }
    }
}
