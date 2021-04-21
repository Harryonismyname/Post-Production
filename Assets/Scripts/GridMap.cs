using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridMap<TGridObject>
{
    public float CellSize { get; }
    public int Height { get; }
    public int Width { get; }
    private readonly TGridObject[,] gridArray;
    private Vector3 _originPosition;

    public GridMap(int height, int width, float cellSize, Vector3 originPosition, Func<int, int, TGridObject> createGridObject)
    {
        Height = height;
        Width = width;
        CellSize = cellSize;
        _originPosition = originPosition;

        gridArray = new TGridObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(x, y);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * CellSize + _originPosition;
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        if (ConstraintValidator.IsWithinBounds(worldPosition, _originPosition, GetWorldPosition(Width, Height)))
        {
            GetXY(worldPosition, out int x, out int y);
            return gridArray[x, y];
        }
        else return default;
    }

    public TGridObject GetGridObject(int x, int y)
    {
        if (ConstraintValidator.IsWithinBounds(GetWorldPosition(x, y), _originPosition, GetWorldPosition(Width, Height)))
        {
            return gridArray[x, y];
        }
        else return default;
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject gridObject)
    {
        if (ConstraintValidator.IsWithinBounds(worldPosition, _originPosition, GetWorldPosition(Width, Height)))
        {
            GetXY(worldPosition, out int x, out int y);
            gridArray[x, y] = gridObject;
        }
    }

    public Vector3 GetCellCenterWorld(Vector3 position)
    {
        GetXY(position, out int x, out int y);
        Vector3 location = GetCellCenter(GetWorldPosition(x, y));
        return location;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / CellSize);
        y = Mathf.FloorToInt(worldPosition.y / CellSize);
    }

    private Vector3 GetCellCenter(Vector3 location)
    {
        location.x += (CellSize / 2);
        location.y += (CellSize / 2);
        return location;
    }
}
