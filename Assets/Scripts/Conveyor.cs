using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : Structure
{
    [SerializeField] private float _movementSpeed;
    private bool _hasDestination;

    public Conveyor(int height, int width, int xPos, int yPos, float movementSpeed) : base(height, width, xPos, yPos)
    {
        _movementSpeed = movementSpeed;
    }
}
