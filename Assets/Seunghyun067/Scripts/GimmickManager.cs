using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : SH.Singleton<GimmickManager>
{
    [SerializeField] private Light[] roomLights;
    [SerializeField] private Renderer[] lightRenderers;
    [SerializeField] private bool isTest;
    [SerializeField] public GameObject controller;

    private bool isElecEnable = false;
    private bool isLightingEnable = false;

    public bool IsElecEnable { get => isElecEnable; }
    public bool IsLightingEnable { get => isLightingEnable; }

    private string targetLayerName;
    public string TargetLayerName { get => targetLayerName; }

    [SerializeField]
    private GameObject line;

    private void Awake()
    {
        line.SetActive(false);
        targetLayerName = "Item";
        if (!isTest)
        {
            targetLayerName = "LightItem";

            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].enabled = false;
                lightRenderers[i].material.SetColor("_EmissionColor", Color.black);
            }
        }        
    }

    public void ElecEnable() => isElecEnable = true;

    public bool LightOn()
    {
        if (!isElecEnable)
            return false;

        for (int i = 0; i < roomLights.Length; i++)
        {
            roomLights[i].enabled = true;
            lightRenderers[i].material.SetColor("_EmissionColor", Color.white);
        }
        isLightingEnable = true;
        targetLayerName = "Item";
        return true;
    }

    public void LineOnOff(bool isEnable) => line.SetActive(isEnable);

}
