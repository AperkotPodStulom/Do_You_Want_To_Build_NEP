using System;
using System.CodeDom.Compiler;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public enum ResourceType
{
    Iron,
    Coal,
    Copper,
    Cotton,
    Wool,
}

public enum LandscapeType
{
    Mountains,
    Plato,
    Hills
}
public class Region : MonoBehaviour
{
    private int logisticPoints;
    private ResourceType resType;
    private LandscapeType landType;

    private void Start()
    {
        GenerateResources();
        GenerateLand();
        GenerateLogisticPoints();
    }

    private void GenerateLogisticPoints()
    {
        switch (landType)
        {
            case LandscapeType.Plato:
                logisticPoints = RandomNumberGenerator.GetInt32(7, 11);
                break;
            case LandscapeType.Hills:
                logisticPoints = RandomNumberGenerator.GetInt32(3, 7);
                break;
            case LandscapeType.Mountains:
                logisticPoints = RandomNumberGenerator.GetInt32(0, 3);
                break;
        }
    }

    private void GenerateLand()
    {
        LandscapeType[] types = new LandscapeType[3]
            { LandscapeType.Hills, LandscapeType.Mountains, LandscapeType.Plato };

        RandomNumberGenerator.Create();
        landType = types[RandomNumberGenerator.GetInt32(0, types.Length)];
    }

    private void GenerateResources()
    {
        ResourceType[] types = new ResourceType[5]
            { ResourceType.Coal, ResourceType.Copper, ResourceType.Cotton, ResourceType.Iron, ResourceType.Wool };

        RandomNumberGenerator.Create();
        resType = types[RandomNumberGenerator.GetInt32(0, types.Length)];
    }

    private void OnMouseDown()
    {
        GameObject.Find("MouseManager").GetComponent<MouseManager>().currentRegion = gameObject;
        
        var informLayer = GameObject.Find("Canvas").transform.GetChild(0);
        informLayer.gameObject.SetActive(true);

        informLayer.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = resType.ToString();
        informLayer.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = landType.ToString();
        informLayer.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = logisticPoints.ToString();
    }

    public void AddLogisticPoint(int amount)
    {
        if (logisticPoints < 10)
        {
            logisticPoints += amount;
            OnMouseDown();
        }
    }
}