using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalGrid
{
    private static int _height = 11;
    private static int _width = 13;
    private static readonly float _cellSize = 1f;
    private static Vector3 _origin = new Vector3(-Width / 2, -Height / 2);
    public static float CellSize { get => _cellSize; }
    public static int Height
    {
        get => _height;
        set
        {
            _height = value;
            UpdateGridMap();
        }
    }
    public static int Width
    {
        get => _width;
        set
        {
            _width = value;
            UpdateGridMap();
        }
    }

    public static GridMap<MapNode> GridMap;

    static GlobalGrid()
    {
        UpdateGridMap();
    }

    private static void UpdateGridMap()
    {
        GridMap = new GridMap<MapNode>(Height, Width, _cellSize, _origin, (int x, int y) => new MapNode(x, y));
    }
}
