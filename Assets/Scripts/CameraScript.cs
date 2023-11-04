using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float size = 5;

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            size++;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            size--;

        GetComponent<Camera>().orthographicSize = size;
    }
}
