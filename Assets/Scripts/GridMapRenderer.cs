using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapRenderer : MonoBehaviour
{
    [SerializeField] private GridMap<MapNode> gridMap = GlobalGrid.GridMap;
    private int _height;
    private int _width;
    private readonly float cellSize = GlobalGrid.CellSize;
    public int Height
    {
        get => _height;
        set
        {
            _height = value;
            GlobalGrid.Height = _height;
        }
    }
    public int Width
    {
        get => _width;
        set
        {
            _width = value;
            GlobalGrid.Width = _width;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x <= gridMap.Width; x++)
        {
            for (int y = 0; y <= gridMap.Height - 1 - 1; y++)
            {
                Gizmos.DrawWireSphere(gridMap.GetWorldPosition(x, y), cellSize / 2);
            }
        }
    }
}
