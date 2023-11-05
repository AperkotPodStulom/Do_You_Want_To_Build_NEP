using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    [HideInInspector] public GameObject currentRegion;

    private bool isOver = false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == null &&
            !GameObject.Find("BuildCanvas").GetComponent<BuildCanvasAnimationManager>().IsOver &&
            (!GameObject.Find("Canvas").transform.GetChild(1).GetChild(0).gameObject.GetComponent<BuildCanvasButton>().IsOver || 
                !GameObject.Find("Canvas").transform.GetChild(1).GetChild(0).gameObject.activeInHierarchy))
        {
            
            currentRegion = null;
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
            
            GameObject.Find("BuildCanvas").GetComponent<Animator>().Play("Close");
        }
    }
}
