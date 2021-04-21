using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstraintValidator
{
    public static bool IsWithinBounds(Vector3 location, Vector3 origin, Vector3 extreme)
    {
        if (location.x >= origin.x && location.y >= origin.y && location.x <= extreme.x && location.y <= extreme.y)
        {
            return true;
        }
        else return false;
    }
}
