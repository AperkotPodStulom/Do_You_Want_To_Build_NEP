using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int Position { get; set; }
    public bool IsOccupied = false;
    public GameObject RegionSeed = null;

    private void FixedUpdate()
    {
        transform.position = (Vector2)Position;
    }

    private void OnMouseDown()
    {
        if (transform.parent != null)
        {
            
        }
    }
}
