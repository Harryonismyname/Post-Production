using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure
{
    public int Height => _height;
    public int Width => _width;
    private int _height;
    private int _width;
    private int _xCoord;
    private int _yCoord;
    private readonly GridMap<MapNode> GridMap = GlobalGrid.GridMap;

    public Structure(int height, int width, int xPos, int yPos)
    {
        _height = height;
        _width = width;
        _xCoord = xPos;
        _yCoord = yPos;
        for (int x = 1; x <= _width; x++) 
        {
            for (int y = 1; x <= _height; y++)
            {
                GridMap.GetGridObject(xPos+x, yPos+y).hasObject = true;
            }
        }
        
    }
}
