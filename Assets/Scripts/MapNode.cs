using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode
{
    public int x;
    public int y;
    public bool hasObject;

    public MapNode(int x, int y)
    {
        this.x = x;
        this.y = y;
        hasObject = false;
    }
}
