using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildCanvasAnimationManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public bool IsOver;
    
    public void SetUnusedButtonsOff()
    {
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
    }

    public void SetUnusedButtonsOn()
    {
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsOver = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        IsOver = false;
    }
}
