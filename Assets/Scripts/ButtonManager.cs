using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void ShowBuildMenu()
    {
        GameObject.Find("BuildCanvas").GetComponent<Animator>().Play("Show");
    }

    public void BuildRoad()
    {
        GameObject.Find("MouseManager").GetComponent<MouseManager>().currentRegion.GetComponent<Region>().AddLogisticPoint(1);
    }
}
