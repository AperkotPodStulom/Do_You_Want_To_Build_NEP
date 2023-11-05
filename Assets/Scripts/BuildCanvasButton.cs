using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildCanvasButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public bool IsOver = false;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsOver = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        IsOver = false;
    }
}
